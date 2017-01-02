using UnityEngine;

public abstract class Ally_Base_Class : MonoBehaviour
{
    //Ally base variables
    public bool isunlocked;

    public int level;
    public int upgradecost;

    //Getter functions
    public bool IsUnlocked { get { return isunlocked; } set { IsUnlocked = value; } }

    public int Level { get { return level; } }
    public int UpgradeCost { get { return upgradecost; } }

    // Use this for initialization
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }
}