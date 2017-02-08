using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Settings : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void PlayButtonPress()
    {
        AudioManager.PlaySoundEffect(AudioManager.SoundEffect.MouseClick);
    }

    public void ResetPlayerData()
    {
        GameControl._control._coins = 0;
        GameControl._control._level = 0;
        GameControl._control._ally1Level = 0;
        GameControl._control._ally1Cost = 0;
        GameControl._control._coinMultiplier = 1;
        GameControl._control._monsterCount = 0;

        GameControl._control.Save();
    }
}