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
    public static List<string> MobWords = new List<string>();
    public static List<string> BossWords = new List<string>();

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

    public float _monsterCount;
    public string[] _words_m;
    public string[] _words_b;
    public int _level;

    private string _filePath = "/playerData.dat";

    public void Save()
    {
        BinaryFormatter bf_writer = new BinaryFormatter();
        FileStream _file = File.Create(Application.persistentDataPath + _filePath);

        //taking data from control to put into saving class.
        playerData data = new playerData();
        {
            data.monsterCount = _monsterCount;
            data.words_m = _words_m;
            data.words_b = _words_b;
            data.level = _level;
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
            _words_m = data.words_m;
            _words_b = data.words_b;
            _level = data.level;
        }
    }

    public bool Load()
    {
        //if file exsists
        if (File.Exists(Application.persistentDataPath + _filePath))
        {
            BinaryFormatter bf_reader = new BinaryFormatter();
            FileStream _file = File.Open(Application.persistentDataPath + _filePath, FileMode.Open);

            playerData data = (playerData)bf_reader.Deserialize(_file);
            _file.Close();

            _monsterCount = data.monsterCount;
            _words_m = data.words_m;
            _level = data.level;
        }
        else //on first load (no previous save, create a save)
        {
            //set variables
            _monsterCount = 0;
            _level = 1;
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
                    _words_m[i] = MobWords[i];
                }
            }
            {
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
                    _words_b[i] = BossWords[i];
                }
            }
            Save();
        }
        return true;
    }
}

//makes the below class able to save to file
[Serializable]
internal class playerData
{
    //how many monsters left to boss
    public float monsterCount;

    //the string of words for this stage. - remember to reload everytime you clear stage.
    public string[] words_m;

    // the words for the bosses.
    public string[] words_b;

    //the current stage
    public int level;
}