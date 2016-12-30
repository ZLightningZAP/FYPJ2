using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_AI : MonoBehaviour {

    public Image Boss_timer;
    public Text TextFeedback; // use to display time left 

    float f_timeLeft;
    float f_totalTime;

	// Update is called once per frame
	void Update () {
        if (GameControl._control._monsterCount >= 10)
        {
            f_timeLeft -= Time.deltaTime;
        }
	}
}
