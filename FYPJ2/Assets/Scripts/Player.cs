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
    }

    // Update is called once per frame
    private void Update()
    {
        //get the joystick movement and apply it here after adjusting the move speed (based on how far the drag from start moving)
        MovePlayer((Input.mousePosition) );
    }

    public void MovePlayer(Vector2 _pos)
    {
        p_base.UpdatePosition(_pos, transform);
    }
}