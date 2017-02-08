using UnityEngine;
using UnityEngine.UI;

public class Player_input : MonoBehaviour
{
    // The string of char required to be filled in - in black
    public Text txt_required;

    // The correctly inputed string of char - in white
    public Text txt_filled;

    //Text for displaying the current level
    public Text txt_Level;

    public Background_Change background;

    public Boss boss;
    public NormalMob mob;
    public Player player;
    public Currency currency;

    private int char_index;
    private char[] char_required;
    private Canvas canvas;

    private static bool spamEnterGuard;

    public Image Boss_timer;
    public Text TextFeedback;

    // Use this for initialization
    private void Start()
    {
        if (GameControl._control._coinMultiplier < 1)
        {
            GameControl._control._coinMultiplier = 1;
        }
        txt_required.text = GameControl._control._words_m[GameControl._control._monsterCount];
        //setting the required text into char array for easier checking
        char_required = txt_required.text.ToCharArray();
        //the current index of the char array.
        char_index = 0;
        spamEnterGuard = false;

        canvas = gameObject.GetComponent<Canvas>();
        Invoke("NextIsMob", 0f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (boss.GoBack)
        {
            GameControl._control._monsterCount = 8;
            NextMonster();
            boss.GoBack = false;
        }
        //if the word has changed , update the checking sequence.
        if (char_required != txt_required.text.ToCharArray())
        {
            char_required = txt_required.text.ToCharArray();
            //update the text size
            txt_filled.fontSize = (int)(((float)txt_required.cachedTextGenerator.fontSizeUsedForBestFit / canvas.scaleFactor) + 1);
        }

        if (boss.f_timeLeft < 0.0f)
        {
            Boss_timer.fillAmount = 0;
            TextFeedback.text = "";
        }

        txt_Level.text = "Level " + GameControl._control._level.ToString() + "." + GameControl._control._monsterCount.ToString();
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
        if (Input.GetKeyDown(KeyCode.Return) && !spamEnterGuard)
        {
            spamEnterGuard = true;

            //check if correct
            if (txt_required.text == txt_filled.text)
            {
                txt_filled.color = Color.green;
                AudioManager.PlaySoundEffect(AudioManager.SoundEffect.CorrectFeedback);
                GivingCurrency();
                Invoke("NextMonster", 0.2f);
            }
            else
            {
                txt_filled.color = Color.red;
                AudioManager.PlaySoundEffect(AudioManager.SoundEffect.WrongFeedback);
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
            GameControl._control._coinMultiplier += 2;
        }
        //if havent reach the minimum monster requirement.
        if (GameControl._control._monsterCount < 10)
        {
            txt_required.text = GameControl._control._words_m[Random.Range(0, GameControl._control._words_m.Length - 1)];
            Invoke("NextIsMob", 1f);
        }
        else
        {
            txt_required.text = GameControl._control._words_b[Random.Range(0, GameControl._control._words_b.Length - 1)];
            Invoke("NextIsBoss", 1f);
        }
        //Debug.Log(txt_required.cachedTextGenerator.fontSizeUsedForBestFit);
        //Debug.Log(txt_filled.fontSize);

        ResetColor();

        //change word required
        //**NOTE randomize word coming out
        char_required = txt_required.text.ToCharArray();

        AudioManager.PlaySoundEffect(AudioManager.SoundEffect.MonsterDie);
        txt_filled.text = "";
        char_index = 0;
    }

    private void GivingCurrency()
    {
        if (GameControl._control._monsterCount < 10)
        {
            currency.AddCoins(GameControl._control._coinMultiplier * 1);
        }
        else if (GameControl._control._monsterCount == 10)
        {
            currency.AddCoins(GameControl._control._coinMultiplier * 5);
        }
    }

    private void ResetColor()
    {
        txt_filled.color = Color.white;
        txt_filled.text = "";
        char_index = 0;
        spamEnterGuard = false;
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