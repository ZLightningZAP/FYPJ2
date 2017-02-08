using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject[] Boss_;
    public Image Boss_timer;
    public Text TextFeedback;

    private float f_timeLeft;
    private int i = 0;
    private int previous;
    private SpriteRenderer spriteRen;
    private RuntimeAnimatorController animcontroller;

    public bool GoBack;

    // Use this for initialization
    private void Start()
    {
        GoBack = false;
        if (GameControl._control._bossTotalTime <= 10)
        {
            GameControl._control._bossTotalTime = 10;
        }

        f_timeLeft = GameControl._control._bossTotalTime;
        previous = -1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (f_timeLeft <= 0.1f && f_timeLeft >= -0.9f)
        {
            f_timeLeft = 100;
            GameControl._control._monsterCount -= 2; //is -2 to counter the +1 in the NextMonster fucnt in Player_input.cs
            GoBack = true;
        }

        if (GameControl._control._monsterCount < 10)
        {
            Boss_timer.fillAmount = 0;
            TextFeedback.text = "";
        }
        else
        {
            f_timeLeft -= Time.deltaTime;

            Boss_timer.fillAmount = f_timeLeft / GameControl._control._bossTotalTime;
            TextFeedback.text = f_timeLeft.ToString().Substring(0, 4);
        }
    }

    public void ChangeBoss()
    {
        f_timeLeft = GameControl._control._bossTotalTime;
        i = Random.Range(0, Boss_.Length);
        if (i != previous)
        {
            spriteRen = Boss_[i].GetComponent<SpriteRenderer>();
            animcontroller = Boss_[i].GetComponent<Animator>().runtimeAnimatorController;

            gameObject.GetComponent<SpriteRenderer>().sprite = spriteRen.sprite;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = animcontroller;
            gameObject.GetComponent<Animator>().speed = 0;
            previous = i;
        }
        else if (i == previous)
        {
            ChangeBoss();
            GameControl._control._monsterCount += 1;
        }
    }

    public void PlayAnim()
    {
        gameObject.GetComponent<Animator>().speed = 1;
    }
}