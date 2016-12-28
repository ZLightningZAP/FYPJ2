/*
 *  This file is a data store of the game, use this to store data of different type 
 *  Remember to call save and load when needed. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl _control;

    void Awake () {
        //making it singleton object
        if(_control == null)
        {
            //make object persistant, so wont destroy at all
            DontDestroyOnLoad(gameObject);

            _control = this;
        }
        else if(_control != this) //make sure there are no duplicates, if have destroy the latter
        {
            Destroy(gameObject);
        }

    }

    public float _money;
    public float _monsterCount;
    public string[] _words;

    string _filePath = "/playerData.dat";
    public void Save()
    {
        BinaryFormatter bf_writer = new BinaryFormatter();
        FileStream _file = File.Create(Application.persistentDataPath + _filePath);

        //taking data from control to put into saving class.
        playerData data = new playerData();
        {
            data.monsterCount = _monsterCount;
            data.words = _words;
        }

        //writing it to that file path
        bf_writer.Serialize(_file, data);

        _file.Close();
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
            _words = data.words;
            return true;
        }
        else
        {
            Debug.Log("File doesnt exsist at: " + Application.persistentDataPath + _filePath);
            return true;
        }
    }
}

//makes the below class able to save to file
[Serializable]
class playerData
{
    public float monsterCount;
    public string[] words;
}
