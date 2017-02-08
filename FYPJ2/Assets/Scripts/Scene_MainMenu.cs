using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_MainMenu : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        GameControl._control.Save();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void playButtonPress()
    {
        AudioManager.PlaySoundEffect(AudioManager.SoundEffect.MouseClick);
    }
}