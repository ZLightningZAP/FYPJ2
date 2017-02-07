using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    private Text text;

    // Use this for initialization
    private void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        text.text = "Coins " + GameControl._control._coins.ToString();
    }

    public int GetCoins()
    {
        return GameControl._control._coins;
    }

    public void AddCoins(int amount)
    {
        GameControl._control._coins = GameControl._control._coins + amount;
    }

    public void MinusCoins(int amount)
    {
        GameControl._control._coins = GameControl._control._coins - amount;
    }
}