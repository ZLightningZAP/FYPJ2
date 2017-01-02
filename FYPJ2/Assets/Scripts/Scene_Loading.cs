using UnityEngine;

public class Scene_Loading : MonoBehaviour
{
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

            GameControl._control._s_BGM = 100;
            GameControl._control._s_SFX = 100;
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