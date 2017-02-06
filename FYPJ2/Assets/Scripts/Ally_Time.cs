using UnityEngine;

public class Ally_Time : Ally_Base_Class
{
    private Boss boss;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        boss = (Boss)FindObjectOfType(typeof(Boss));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        //Check if the character is unlocked
        if (IsUnlocked == true)
        {
            UnlockedYes();
        }
        else
        {
            UnlockedNo();
        }

        //update the text on the level
        Level_text.text = "level " + Level.ToString();
    }

    //If ally is unlocked
    private void UnlockedYes()
    {
        Button_text.text = "Upgrade Ally";
        gameObject.SetActive(true);
    }

    //If ally is not unlocked
    private void UnlockedNo()
    {
        Button_text.text = "Unlock Ally";
        gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        //If ally hasnt been unlocked yet
        if (Button_text.text == "Unlock Ally")
        {
            UnlockedYes();
            isunlocked = true;
        }

        //If ally has been unlocked and can be upgraded
        if (Button_text.text == "Upgrade Ally")
        {
            Level += 1;
            Upgrade();
        }
    }

    private void Upgrade()
    {
        if (Level == 1)
        {
            boss.f_totalTime += 0.3f;
        }
        else if (Level % 5 == 0)
        {
            boss.f_totalTime += 0.3f;
        }
    }
}