using UnityEngine;
using UnityEngine.UI;

public class Boss_AI : MonoBehaviour
{
    public Image Boss_timer;
    public Text TextFeedback; // use to display time left
    public float f_totalTime;
    public int i_totalHealth;

    private float f_timeLeft;
    private int i_healthLeft;

    // Use this for initialization
    private void Start()
    {
        //Set time left to the total time
        f_timeLeft = f_totalTime;
        //Set boss health to the maximum health
        i_healthLeft = i_totalHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameControl._control._monsterCount >= 10)
        {
            f_timeLeft -= Time.deltaTime;
        }
    }
}