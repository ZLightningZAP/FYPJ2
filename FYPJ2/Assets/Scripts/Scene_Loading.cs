using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

public class Scene_Loading : MonoBehaviour
{

    public static List<string> MobWords = new List<string>();
    public static List<string> BossWords = new List<string>();

    // Use this for initialization
    private void Start()
    {
        if (GameControl._control.Load()) //if an existing saved data
        {
            GetComponent<Scene_navigation>().GoTo_MainMenu();
        }
        else //create the save data with default variables first
        {
            //set variables
            GameControl._control._monsterCount = 0;
            GameControl._control._level = 1;
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

                GameControl._control._words_m = new string[MobWords.Count];
                for (int i = 0; i < MobWords.Count; ++i)
                {
                    GameControl._control._words_m[i] = MobWords[i].ToUpper();
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
                GameControl._control._words_b = new string[BossWords.Count];
                for (int i = 0; i < BossWords.Count; ++i)
                {
                    GameControl._control._words_b[i] = BossWords[i].ToUpper();
                }
            }
            GameControl._control.Save();
          
        }
           
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameControl._control.Load()) //if an existing saved data
        {
            GetComponent<Scene_navigation>().GoTo_MainMenu();
        }
    }
}