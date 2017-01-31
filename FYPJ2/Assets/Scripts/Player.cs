using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    // public int Damage { get { return damage; } }
    // public int Level { get { return level; } }

    //private int damage;
    // private int level;
    private int i;

    private int previous;

    //Animation
    private Animator anim;

    private List<string> animations = new List<string>();

    // Use this for initialization
    private void Start()
    {
        i = 0;
        previous = 0;
        anim = gameObject.GetComponent<Animator>();
        anim.speed = 0;
        foreach (AnimationClip ac in anim.runtimeAnimatorController.animationClips)
        {
            animations.Add(ac.name);
        }
    }

    public void PlayAnim()
    {
        i = Random.Range(0, animations.Count);
        if (i != previous)
        {
            anim.Play(animations[i]);
            anim.speed = 1;
            previous = i;
        }
        else if (i == previous)
        {
            PlayAnim();
        }
    }
}