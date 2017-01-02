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

    /*
     * DO NOT PUT ANYTHING ABOVE THIS COMMENT.
     * Any variable must be declared after this line.
    */
    public int _monsterCount;
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
            _words_m = data.words_m;
            _words_b = data.words_b;
            _level = data.level;

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

    //the string of words for this stage. - remember to reload everytime you clear stage.
    public string[] words_m;

    // the words for the bosses.
    public string[] words_b;

    //the current stage
    public int level;

    /*   ====  SETTINGS MODIFIED ====   */

    //saved SFX(sound) volume; Default - 100
    public int sound_SFX; // 0 - 100

    //saved BGM(music) volume; Default - 100
    public int sound_BGM; // 0 - 100

    //saved text size; Default - 100 **note: if want to make bigger..need to modify the box.**
    public int txt_size;
}