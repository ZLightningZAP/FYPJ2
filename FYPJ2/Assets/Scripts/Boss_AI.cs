using UnityEngine;
using UnityEngine.UI;

public class Boss_AI : MonoBehaviour
{
    public Image Boss_timer;
    public Text TextFeedback; // use to display time left
    public float f_totalTime;
    public int i_totalHealth;

    public float f_timeLeft;
    private int i_healthLeft;

    //Monster sprites
    public Image monster_;

    public Sprite[] spriteArr_boss;
    public Sprite[] spriteArr_mob;

    private int currentMonster;

    // Use this for initialization
    private void Start()
    {
        currentMonster = GameControl._control._monsterCount;

        //Set time left to the total time
        f_timeLeft = f_totalTime;
        //Set boss health to the maximum health
        i_healthLeft = i_totalHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameControl._control._monsterCount < 10)
        {
            Boss_timer.fillAmount = 0;
            TextFeedback.text = "";
        }
        else
        {
            f_timeLeft -= Time.deltaTime;

            Boss_timer.fillAmount = f_timeLeft / f_totalTime;
            TextFeedback.text = f_timeLeft.ToString();
        }

        if (currentMonster != GameControl._control._monsterCount)
        {
            if (GameControl._control._monsterCount < 10)
            {
                monster_.GetComponent<Image>().sprite = spriteArr_mob[0];
            }
            else
            {
                monster_.GetComponent<Image>().sprite = spriteArr_boss[0];
            }

            currentMonster = GameControl._control._monsterCount;
        }
    }
}