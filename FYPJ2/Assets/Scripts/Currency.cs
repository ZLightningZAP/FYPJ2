using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    private int coin;

    private Text text;

    // Use this for initialization
    private void Start()
    {
        coin = 10;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        text.text = "Coins " + coin.ToString();
    }

    public int GetCoins()
    {
        return coin;
    }

    public void AddCoins(int amount)
    {
        coin = coin + amount;
    }

    public void MinusCoins(int amount)
    {
        coin = coin - amount;
    }
}