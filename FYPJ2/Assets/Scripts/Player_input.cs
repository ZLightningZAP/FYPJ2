using UnityEngine;
using UnityEngine.UI;

public class Player_input : MonoBehaviour
{
    // The string of char required to be filled in - in black
    public Text txt_required;

    // The correctly inputed string of char - in white
    public Text txt_filled;

    // The current monster being dissplayed
    public Image monster_;

    private int char_index;
    private char[] char_required;

    //the sprite images of the Boss monsters
    public Sprite[] spriteArr_boss;

    //the sprite images of monsters
    public Sprite[] spriteArr_monster;

    // Use this for initialization
    private void Start()
    {
        txt_required.text = GameControl._control._words_m[GameControl._control._monsterCount];
        //setting the required text into char array for easier checking
        char_required = txt_required.text.ToCharArray();
        //the current index of the char array.
        char_index = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        //if the word has changed , update the checking sequence.
        if (char_required != txt_required.text.ToCharArray())
        {
            char_required = txt_required.text.ToCharArray();
        }

        checkKey();
    }

    //Trigger different feedback during runtime.
    private void checkKey()
    {
        //checking across all alphabet - will convert all to upper case (because keycode), NOTE: if got error - check that the required are all in CAPS
        for (var i = KeyCode.A; i < KeyCode.Z; i++)
        {
            if (Input.GetKeyDown(i) && char_index < char_required.Length )
            {
                string crntChar = i.ToString();
                if (crntChar == char_required[char_index].ToString().ToUpper())
                {
                    //if correct
                    txt_filled.text += crntChar;
                    char_index++;
                }
                else
                {
                    //negative feedback
                }
            }
        }

        //when enter key is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //check if correct
            if (txt_required.text == txt_filled.text)
            {
                txt_filled.color = Color.green;

                Debug.Log("monster killed");

                Invoke("NextMonster", 0.2f);
            }
            else
            {
                txt_filled.color = Color.red;
                
                //resets the color back to white after 0.2s
                Invoke("ResetColor", 0.2f);
            }
        }
    }

    private void NextMonster()
    {
        //successful , change monster, drop gold..etc
        GameControl._control._monsterCount += 1;
        //if havent reach the minimum monster requirement.
        if (GameControl._control._monsterCount < 10)
        {
            txt_filled.fontSize = txt_required.fontSize;
            monster_.GetComponent<Image>().sprite = spriteArr_monster[0];
            txt_required.text = GameControl._control._words_m[GameControl._control._monsterCount];
        }
        else
        {
            monster_.GetComponent<Image>().sprite = spriteArr_boss[0];
            txt_required.text = GameControl._control._words_b[GameControl._control._monsterCount];
            txt_filled.fontSize = txt_required.cachedTextGenerator.fontSizeUsedForBestFit + 15;
            if (GameControl._control._monsterCount >= 10)
            {
                GameControl._control._monsterCount = 0;
            }
        }

        ResetColor();

        //change word required
        //**NOTE randomize word coming out
        char_required = txt_required.text.ToCharArray();

        txt_filled.text = "";
        char_index = 0;
    }

    private void ResetColor()
    {
        txt_filled.color = Color.white;
    }
}