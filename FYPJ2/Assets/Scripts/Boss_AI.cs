﻿using UnityEngine;
using UnityEngine.Experimental.Director;
using UnityEngine.UI;

public class Boss_AI : MonoBehaviour
{
    public GameObject[] Boss;
    public Image Boss_timer;
    public Text TextFeedback;
    public float f_totalTime;
    public float f_timeLeft;

    private SpriteRenderer spriteRen;
    private RuntimeAnimatorController animcontroller;
    private int i = 0;
    private int previous;

    // Use this for initialization
    private void Start()
    {
        //Setting the time
        f_timeLeft = f_totalTime;

        ChangeBoss();
        previous = -1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameControl._control._monsterCount < 10)
        {
            Boss_timer.fillAmount = 0;
            TextFeedback.text = "";
        }
        else
        {
            f_timeLeft -= Time.deltaTime;

            Boss_timer.fillAmount = f_timeLeft / f_totalTime;
            TextFeedback.text = f_timeLeft.ToString().Substring(0, 4);
        }
    }

    public void ChangeBoss()
    {
        i = Random.Range(0, Boss.Length);
        if (i != previous)
        {
            spriteRen = Boss[i].GetComponent<SpriteRenderer>();
            animcontroller = Boss[i].GetComponent<Animator>().runtimeAnimatorController;

            gameObject.GetComponent<SpriteRenderer>().sprite = spriteRen.sprite;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = animcontroller;
            gameObject.GetComponent<Animator>().speed = 0;
            previous = i;
        }
        else if (i == previous)
        {
            ChangeBoss();
        }
    }

    public void PlayAnim()
    {
        gameObject.GetComponent<Animator>().speed = 1;
    }
}