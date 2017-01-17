using UnityEngine;
using UnityEngine.UI;

public class Background_Change : MonoBehaviour
{
    public Sprite[] BackgroundArray;

    private int i;

    private void Start()
    {
        i = Random.Range(0, BackgroundArray.Length);
        gameObject.GetComponent<Image>().sprite = BackgroundArray[i];
    }

    //Call this function to randomly change background
    public void ChangeBG()
    {
        i = Random.Range(0, BackgroundArray.Length);
        gameObject.GetComponent<Image>().sprite = BackgroundArray[i];
    }
}