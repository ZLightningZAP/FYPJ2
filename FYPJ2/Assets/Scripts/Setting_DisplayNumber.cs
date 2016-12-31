using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting_DisplayNumber : MonoBehaviour
{
    public Slider Slider;
    private float Value;

    // Use this for initialization
    private void Start()
    {
        //Set slider to the max value
        Slider.value = 100;
    }

    // Update is called once per frame
    private void Update()
    {
        Value = Slider.value;
        gameObject.GetComponent<Text>().text = Value.ToString();
    }
}