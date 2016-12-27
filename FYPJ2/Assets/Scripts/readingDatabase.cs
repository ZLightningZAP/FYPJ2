using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class readingDatabase : MonoBehaviour {

    string _filePath = "/playerData.dat";

	// Use this for initialization
	void Start () {
      
	}
	
	public void Save()
    {
        BinaryFormatter bf_writer = new BinaryFormatter();
        FileStream _file = File.Create(Application.persistentDataPath + _filePath);

        //taking data from control to put into saving class.
        playerData data = new playerData();
        {
            data._monsterCount = GameControl._control._monsterCount;

        }

        //writing it to that file path
        bf_writer.Serialize(_file, data);

        _file.Close();
    }

    public void Load()
    {
        //if file exsists
        if(File.Exists(Application.persistentDataPath + _filePath))
        {
            BinaryFormatter bf_reader = new BinaryFormatter();
            FileStream _file = File.Open(Application.persistentDataPath + _filePath, FileMode.Open);

            playerData data = (playerData)bf_reader.Deserialize(_file);
            _file.Close();

            GameControl._control._monsterCount = data._monsterCount;
        }
        
    }
}

//makes the below class able to save to file
[Serializable]
class playerData
{
    public float _monsterCount; 

}
