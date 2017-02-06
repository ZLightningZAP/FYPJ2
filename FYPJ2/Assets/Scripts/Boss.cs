using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject[] Boss_;
    public Image Boss_timer;
    public Text TextFeedback;
    public float f_totalTime;

    private float f_timeLeft;
    private int i = 0;
    private int previous;
    private SpriteRenderer spriteRen;
    private RuntimeAnimatorController animcontroller;

    // Use this for initialization
    private void Start()
    {
        //Setting the time
        f_timeLeft = f_totalTime;
        previous = -1;
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
            TextFeedback.text = f_timeLeft.ToString().Substring(0, 4);
        }
    }

    public void ChangeBoss()
    {
        f_timeLeft = f_totalTime;
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
        }
    }

    public void PlayAnim()
    {
        gameObject.GetComponent<Animator>().speed = 1;
    }
}