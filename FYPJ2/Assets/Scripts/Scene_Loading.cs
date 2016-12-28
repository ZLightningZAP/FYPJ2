using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Loading : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameControl._control.Load())
            GetComponent<Scene_navigation>().GoTo_MainMenu();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
