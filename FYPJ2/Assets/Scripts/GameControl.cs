/*
 *  This file is a data store of the game, use this to store data of different type
 *  Remember to call save and load when needed.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl _control;

    private void Awake()
    {
        //making it singleton object
        if (_control == null)
        {
            //make object persistant, so wont destroy at all
            DontDestroyOnLoad(gameObject);

            _control = this;
        }
        else if (_control != this) //make sure there are no duplicates, if have destroy the latter
        {
            Destroy(gameObject);
        }
    }

    /* =====  DO NOT PUT ANYTHING ABOVE THIS COMMENT. ==== */

    public static List<string> MobWords = new List<string>();
    public static List<string> BossWords = new List<string>();

    public int _monsterCount;
    public string[] _words_m;
    public string[] _words_b;
    public int _level;
    public float _s_BGM;
    public float _s_SFX;
    public int _coins;

    private string _filePath = "/playerData.dat";

    public void Save()
    {
        //Assign all the values for saving
        _s_SFX = AudioManager.SFXVolume;
        _s_BGM = AudioManager.BGMVolume;

        BinaryFormatter bf_writer = new BinaryFormatter();
        FileStream _file = File.Create(Application.persistentDataPath + _filePath);

        //taking data from control to put into saving class.
        playerData data = new playerData();
        {
            data.monsterCount = _monsterCount;
            data.level = _level;
            data.sound_BGM = _s_BGM;
            data.sound_SFX = _s_SFX;
            data.coins = _coins;
        }

        //writing it to that file path
        bf_writer.Serialize(_file, data);

        _file.Close();
    }

    public void ForceLoad()
    {
        //if file exsists
        if (File.Exists(Application.persistentDataPath + _filePath))
        {
            BinaryFormatter bf_reader = new BinaryFormatter();
            FileStream _file = File.Open(Application.persistentDataPath + _filePath, FileMode.Open);

            playerData data = (playerData)bf_reader.Deserialize(_file);
            _file.Close();

            _monsterCount = data.monsterCount;
            _level = data.level;
            _s_BGM = data.sound_BGM;
            _s_SFX = data.sound_SFX;
            _coins = data.coins;

            if (AudioManager._audioControl != null)
            {
                //Assign the values to the AudioManager
                AudioManager.SetBGMVolume(_s_BGM);
                AudioManager.SetEffectVolume(_s_SFX);
            }
            {
                //**READ THE WORDS TEXT FILE**
                //Clean the array before loading again
                MobWords.Clear();
                StreamReader reader = new StreamReader(Application.streamingAssetsPath + "/NormalWords.txt");
                while (!reader.EndOfStream)
                {
                    MobWords.Add(reader.ReadLine());
                }
                //Close the reader
                reader.Close();

                _words_m = new string[MobWords.Count];
                for (int i = 0; i < MobWords.Count; ++i)
                {
                    _words_m[i] = MobWords[i].ToUpper();
                }

                //**READ THE WORDS TEXT FILE**
                //Clean the array before loading again
                BossWords.Clear();
                StreamReader reader1 = new StreamReader(Application.streamingAssetsPath + "/BossWords.txt");
                while (!reader1.EndOfStream)
                {
                    BossWords.Add(reader1.ReadLine());
                }
                //Close the reader
                reader1.Close();
                _words_b = new string[BossWords.Count];
                for (int i = 0; i < BossWords.Count; ++i)
                {
                    _words_b[i] = BossWords[i].ToUpper();
                }
            }
        }
    }

    //will return true if there is an existing saved file
    //if return false, means no previous records
    public bool Load()
    {
        Debug.Log(Application.persistentDataPath + _filePath);
        //if file exsists
        if (File.Exists(Application.persistentDataPath + _filePath))
        {
            BinaryFormatter bf_reader = new BinaryFormatter();
            FileStream _file = File.Open(Application.persistentDataPath + _filePath, FileMode.Open);

            playerData data = (playerData)bf_reader.Deserialize(_file);
            _file.Close();

            _monsterCount = data.monsterCount;
            _level = data.level;
            _s_BGM = data.sound_BGM;
            _s_SFX = data.sound_SFX;
            _coins = data.coins;

            {
                //**READ THE WORDS TEXT FILE**
                //Clean the array before loading again
                MobWords.Clear();
                StreamReader reader = new StreamReader(Application.streamingAssetsPath + "/NormalWords.txt");
                while (!reader.EndOfStream)
                {
                    MobWords.Add(reader.ReadLine());
                }
                //Close the reader
                reader.Close();

                _words_m = new string[MobWords.Count];
                for (int i = 0; i < MobWords.Count; ++i)
                {
                    _words_m[i] = MobWords[i].ToUpper();
                }

                //**READ THE WORDS TEXT FILE**
                //Clean the array before loading again
                BossWords.Clear();
                StreamReader reader1 = new StreamReader(Application.streamingAssetsPath + "/BossWords.txt");
                while (!reader1.EndOfStream)
                {
                    BossWords.Add(reader1.ReadLine());
                }
                //Close the reader
                reader1.Close();
                _words_b = new string[BossWords.Count];
                for (int i = 0; i < BossWords.Count; ++i)
                {
                    _words_b[i] = BossWords[i].ToUpper();
                }
            }

            return true;
        }

        return false;
    }
}

//makes the below class able to save to file
[Serializable]
internal class playerData
{
    //how many monsters left to boss
    public int monsterCount;

    //the current stage
    public int level;

    //the current amount of oins
    public int coins;

    /*   ====  SETTINGS MODIFIED ====   */

    //saved SFX(sound) volume; Default - 100
    public float sound_SFX; // 0 - 100

    //saved BGM(music) volume; Default - 100
    public float sound_BGM; // 0 - 100
}