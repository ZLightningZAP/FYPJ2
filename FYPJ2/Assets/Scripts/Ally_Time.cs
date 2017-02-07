using UnityEngine;

public class Ally_Time : Ally_Base_Class
{
    public int UpgradeMultiplier;
    private Boss boss;
    private Currency currency;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        boss = (Boss)FindObjectOfType(typeof(Boss));
        currency = (Currency)FindObjectOfType(typeof(Currency));
        if (GameControl._control._ally1Cost == 0)
        {
            GameControl._control._ally1Cost = 1;
        }
        GameControl._control._ally1Cost = 1 * GameControl._control._ally1Cost;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        //Check if the character is unlocked
        if (GameControl._control._ally1Level >= 1)
        {
            UnlockedYes();
        }
        else
        {
            UnlockedNo();
        }

        //update the text on the level
        Level_text.text = "Level " + GameControl._control._ally1Level.ToString();
        //update the cost of the next upgrade
        Upgrade_text.text = "Cost " + GameControl._control._ally1Cost.ToString();
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
        if (GameControl._control._ally1Level == 0)
        {
            if (currency.GetCoins() >= GameControl._control._ally1Cost)
            {
                currency.MinusCoins(GameControl._control._ally1Cost);
                UnlockedYes();
                GameControl._control._ally1Level += 1;
                Upgrade();
            }
        }

        //If ally has been unlocked and can be upgraded
        if (GameControl._control._ally1Level >= 1)
        {
            if (currency.GetCoins() >= GameControl._control._ally1Cost)
            {
                currency.MinusCoins(GameControl._control._ally1Cost);
                GameControl._control._ally1Level += 1;
                Upgrade();
            }
        }
    }

    private void Upgrade()
    {
        GameControl._control._ally1Cost = GameControl._control._ally1Cost * UpgradeMultiplier;
        //Add total time depending on how many level is the ally
        if (Level == 1)
        {
            GameControl._control._bossTotalTime += 0.3f;
        }
        else if (Level % 5 == 0)
        {
            GameControl._control._bossTotalTime += 0.3f;
        }
    }
}