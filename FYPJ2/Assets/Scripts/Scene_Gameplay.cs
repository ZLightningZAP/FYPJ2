﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Gameplay : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
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