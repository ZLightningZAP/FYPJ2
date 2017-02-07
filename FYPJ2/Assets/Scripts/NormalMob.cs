using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMob : MonoBehaviour
{
    public GameObject[] mob;

    private SpriteRenderer spriteRen;
    private RuntimeAnimatorController animcontroller;
    private int i = 0;
    private int previous;

    // Use this for initialization
    private void Start()
    {
        previous = -1;
    }

    //Call this function to change normal mobs
    public void ChangeMob()
    {
        i = Random.Range(0, mob.Length);
        if (i != previous)
        {
            spriteRen = mob[i].GetComponent<SpriteRenderer>();
            animcontroller = mob[i].GetComponent<Animator>().runtimeAnimatorController;

            gameObject.GetComponent<SpriteRenderer>().sprite = spriteRen.sprite;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = animcontroller;
            gameObject.GetComponent<Animator>().speed = 0;
            previous = i;
        }
        else if (i == previous)
        {
            ChangeMob();
            GameControl._control._monsterCount += 1;
        }
    }

    public void PlayAnim()
    {
        gameObject.GetComponent<Animator>().speed = 1;
    }
}