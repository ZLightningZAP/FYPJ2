using UnityEngine;
using UnityEngine.UI;

public class Setting_Music : MonoBehaviour
{
    public Slider Slider;
    private float Value;

    // Use this for initialization
    private void Start()
    {
        //Set slider to the max value
        Slider.value = GameControl._control._s_BGM * 100;
    }

    //Call this function only when the slider value changes = More efficient
    public void ValueChange()
    {
        Value = Slider.value;
        gameObject.GetComponent<Text>().text = Value.ToString();
        //call the audio manager to set the BGM volume
        AudioManager.SetBGMVolume((Value * 0.01f));
    }
}