using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    //the base class of the player
    Character p_base;

    // Use this for initialization
    private void Start()
    {
        //get the "Character.cs" script from the player GameObject
        //Remember to add!
        p_base = GetComponent<Character>();

        p_base.SetHealth(0);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}