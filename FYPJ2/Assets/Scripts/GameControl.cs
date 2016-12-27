using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
