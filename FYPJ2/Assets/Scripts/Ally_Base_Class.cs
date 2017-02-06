using UnityEngine;
using UnityEngine.UI;

public abstract class Ally_Base_Class : MonoBehaviour
{
    //Ally base variables
    public bool isunlocked;

    public int level;
    public int upgradecost;
    public int damage;
    public Text Button_text;
    public Button Button_button;
    public Text Level_text;
    public Text Upgrade_text;

    //public Button Upgrade;

    //Getter functions
    public bool IsUnlocked { get { return isunlocked; } set { IsUnlocked = value; } }

    public int Level { get { return level; } set { level = value; } }
    public int UpgradeCost { get { return upgradecost; } set { upgradecost = value; } }
    public int Damage { get { return damage; } set { damage = value; } }

    // Use this for initialization
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }
}