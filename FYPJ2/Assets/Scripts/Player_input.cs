using UnityEngine;
using UnityEngine.UI;

public class Player_input : MonoBehaviour
{
    // The string of char required to be filled in - in black
    public Text txt_required;

    // The correctly inputed string of char - in white
    public Text txt_filled;

    public Background_Change background;

    public Boss boss;
    public NormalMob mob;
    public Player player;
    public Currency currency;

    private int char_index;
    private char[] char_required;
    private Canvas canvas;

    // Use this for initialization
    private void Start()
    {
        txt_required.text = GameControl._control._words_m[GameControl._control._monsterCount];
        //setting the required text into char array for easier checking
        char_required = txt_required.text.ToCharArray();
        //the current index of the char array.
        char_index = 0;

        canvas = gameObject.GetComponent<Canvas>();
        Invoke("NextIsMob", 0f);
    }

    // Update is called once per frame
    private void Update()
    {
        //if the word has changed , update the checking sequence.
        if (char_required != txt_required.text.ToCharArray())
        {
            char_required = txt_required.text.ToCharArray();
            //update the text size
            txt_filled.fontSize = (int)(((float)txt_required.cachedTextGenerator.fontSizeUsedForBestFit / canvas.scaleFactor) + 1);
        }

        checkKey();
    }

    //Trigger different feedback during runtime.
    private void checkKey()
    {
        //checking across all alphabet - will convert all to upper case (because keycode), NOTE: if got error - check that the required are all in CAPS
        for (var i = KeyCode.A; i <= KeyCode.Z; i++)
        {
            if (Input.GetKeyDown(i) && char_index < char_required.Length)
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
                Invoke("NextMonster", 0.2f);
                //currency.AddCoins(100);
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
        Invoke("PlayAnim", 0f);
        Invoke("PlayCharAnim", 0f);
        //successful , change monster, drop gold..etc
        GameControl._control._monsterCount += 1;
        if (GameControl._control._monsterCount > 10) //after every boss fight, go back to normal monsters.
        {
            //Change BG after every boss fight
            background.ChangeBG();
            GameControl._control._level += 1;
            GameControl._control._monsterCount = 0;
        }
        //if havent reach the minimum monster requirement.
        if (GameControl._control._monsterCount < 10)
        {
            txt_required.text = GameControl._control._words_m[GameControl._control._monsterCount + GameControl._control._level * 10];
            Invoke("NextIsMob", 1f);
        }
        else
        {
            txt_required.text = GameControl._control._words_b[GameControl._control._monsterCount + GameControl._control._level];
            Invoke("NextIsBoss", 1f);
        }
        //Debug.Log(txt_required.cachedTextGenerator.fontSizeUsedForBestFit);
        //Debug.Log(txt_filled.fontSize);

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

    private void NextIsMob()
    {
        mob.ChangeMob();
    }

    private void NextIsBoss()
    {
        boss.ChangeBoss();
    }

    private void PlayAnim()
    {
        mob.PlayAnim();
    }

    private void PlayCharAnim()
    {
        player.PlayAnim();
    }
}