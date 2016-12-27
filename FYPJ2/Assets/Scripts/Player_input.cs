using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_input : MonoBehaviour
{
    public Text txt_required;
    public Text txt_filled;
    public Image monster_;
    int char_index;
    char[] char_required;

    // Use this for initialization
    void Start()
    {
        char_required = txt_required.text.ToCharArray();
        char_index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkKey();    
    }

    void checkKey()
    {
        for(var i = KeyCode.A ; i < KeyCode.Z; i++)
        {
            if (Input.GetKeyDown(i))
            {
                string crntChar = i.ToString();
                if (crntChar == char_required[char_index].ToString().ToUpper())
                {
                    
                    txt_filled.text += crntChar;
                    char_index++;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(txt_required.text == txt_filled.text)
            {
                //successful , change monster, drop gold..etc
                GameControl._control._monsterCount++; //make sure that when the _monsterCount reaches 10, set next monster to BOSS.
            }
            else
            {
                txt_filled.text = "";
                char_index = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            txt_filled.text = txt_filled.text.Remove(txt_filled.text.Length - 1);
            char_index--;
        }
    }


}