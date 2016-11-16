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
    
	// Use this for initialization
	void Start () {
        char_health = 10;
        char_attack = 1;
        char_moveSpeed = 1;
	}

    /*The Init function for this character
    * @param : _health  : the health of this character
    * @param : _dmg     : the attack of this character
    * @param : _ms      : the movement speed of ths char */
    public void SetCharInfo(int _health, int _atk, int _ms)
    {
        SetHealth(_health);
        SetAtk(_atk);
        SetMS(_ms);
    }

	// Update is called once per frame
	void Update () {
	
	}

    //Sets this character's health
    //@param : _health : value of health to set to NOT minus by
    public void SetHealth(int _health)
    {
        char_health = _health;
    }

    //minus the health of the character
    //@param : _damage : the number to minus the health by
    public void minusHealth(int _damage)
    {
        char_health -= _damage;
    }

    //Set the character's attack
    //@param : _atk : amount of damage this char can do
    public void SetAtk(int _atk)
    {
        char_attack = _atk;
    }

    //Set the character's movement speed
    //@param : _ms : the speed of this character
    public void SetMS(int _ms)
    {
        char_moveSpeed = _ms;
    }
}
