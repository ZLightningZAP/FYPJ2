using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour {
    /*
     * This class is called to get to the different scenes 
     *  Main menu, , options, town, field ,  boss room..etc
     */

    // Use this for initialization
    void Start () {
	
	}

    //Go to the main menu scene
    //Can go to Option and town 
    public void gotoMainMenu()
    {
        SceneManager.LoadScene("scene_MainMenu");
    }

    //Go to the Town ( safe zone)
    //can go to main menu, option, floor
    public void gotoTown()
    {
        SceneManager.LoadScene("scene_town");
    }

    //Go to the option menu
    //can go to main menu OR go back to where was previously accessed. (use player pref to store char)
    public void gotoOptionMenu()
    {
        
    }

    //Go to the floor( safe zone)
    //can go to town , option, and Boss room IF die go back to town
    public void gotoFloor()
    {
        //remember to get the floor numuber saved in the player pref to set the monster data in floor
    }

    //Go to the Boss room (to unlock floor)
    //can go to option and floor IF die , go back to town
    public void gotoBossRoom()
    {

    }
}
