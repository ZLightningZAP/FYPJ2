using UnityEngine;
using UnityEngine.Experimental.Director;
using UnityEngine.UI;

public class Boss_AI : MonoBehaviour
{
    public GameObject[] Boss;
    public Image Boss_timer;
    public Text TextFeedback;
    public float f_totalTime;
    public int i_totalHealth;
    public float f_timeLeft;
    public string currentMonster;

    private int i_healthLeft;
    private SpriteRenderer spriteRen;
    private RuntimeAnimatorController animcontroller;
    private int i = 0;
    private AnimationClip[] animclip;
    private AnimationClipPlayable clipPlayable;

    // Use this for initialization
    private void Start()
    {
        //Setting the time
        f_timeLeft = f_totalTime;
        i_healthLeft = i_totalHealth;

        ChangeBoss();
        PlayAnim();
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
        i = Random.Range(0, Boss.Length);
        spriteRen = Boss[i].GetComponent<SpriteRenderer>();
        animcontroller = Boss[i].GetComponent<Animator>().runtimeAnimatorController;

        gameObject.GetComponent<SpriteRenderer>().sprite = spriteRen.sprite;
        gameObject.GetComponent<Animator>().runtimeAnimatorController = animcontroller;
        gameObject.GetComponent<Animator>().Stop();
    }

    public void PlayAnim()
    {
        animclip = gameObject.GetComponent<Animator>().runtimeAnimatorController.animationClips;
        clipPlayable = AnimationClipPlayable.Create(animclip[0]);
        gameObject.GetComponent<Animator>().Play(clipPlayable);
    }
}