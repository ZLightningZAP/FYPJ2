using UnityEngine;
using System.Collections;


//This is a base class for all characters
public class Character : MonoBehaviour {
    
    //Health of this character
    int char_health;

    //Attack of this character *Note: Not attack speed
    int char_attack;

    //How many units can this character move by.
    int char_moveSpeed;

    //The position of this character.
    Vector2 char_pos;
    
	// Use this for initialization
	void Start () {
        char_health = 10;
        char_attack = 1;
        char_moveSpeed = 1;
        char_pos = Vector2.zero;
    }

    /* The Init function for this character
    * @param : _health  : the health of this character
    * @param : _dmg     : the attack of this character
    * @param : _ms      : the movement speed of ths char
    * @param : _pos     : the spawn position of the character
    */
    public void SetCharInfo(int _health, int _atk, int _ms, Vector2 _pos)
    {
        SetHealth(_health);
        SetAtk(_atk);
        SetMS(_ms);
        char_pos = _pos;
    }

    /*  Sets this character's health
    *   @param : _health : value of health to set to NOT minus by
    */
    public void SetHealth(int _health)
    {
        char_health = _health;
    }

    /*  minus the health of the character
    *   @param : _damage : the number to minus the health by
    */
    public void minusHealth(int _damage)
    {
        char_health -= _damage;
    }

    /*  Set the character's attack
    *   @param : _atk : amount of damage this char can do
    */
    public void SetAtk(int _atk)
    {
        char_attack = _atk;
    }

    /*  Set the character's movement speed
    *   @param : _ms : the speed of this character
    */
    public void SetMS(int _ms)
    {
        char_moveSpeed = _ms;
    }

    /*  Updates the position of the character based on position passed in and movespeeed of character. 
     *  **NOTE: if want to appy intertia, change the movespeed value.
     *  @param : _pos : the new position to move to (Vector2) 
     */
    public void UpdatePosition(Vector2 _pos, Transform _transform)
    {
        Vector2 _dir = _pos - char_pos;
        _dir.Normalize();

        char_pos.x += _dir.x * char_moveSpeed;
        char_pos.y += _dir.y * char_moveSpeed;

        transform.position = Vector2.Lerp(transform.position, char_pos, char_moveSpeed);
    }

    /*  Returns the current position of this character
     *  @returnType : Vector2
     */
    public Vector2 getPosition()
    {
        return char_pos;
    }

    /*  Sets the position of this char
     *  @param  : _pos  : the new position to Force set.
     */
    public void ForceSetPosition( Vector2 _pos)
    {
        char_pos = _pos;
    }
}
