using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchManager : MonoBehaviour
{
    public Slider slider;
    public float speed;
    private bool isIncreasing;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.instance.gameMode == GAMEMODE.IDLE)
        {
            GameManager.instance.player.Launch(slider.value);
            GameManager.instance.gameMode = GAMEMODE.LAUNCHED;
        }
        UpdateBar();
    }

    public void UpdateBar()
    {
        if (GameManager.instance.gameMode == GAMEMODE.LAUNCHED) return;

        if (isIncreasing)
        {
            slider.value += speed * Time.deltaTime;
            if(slider.value >= slider.maxValue) isIncreasing = false;
            return;
        }
       
        slider.value -= speed * Time.deltaTime;
        if (slider.value <= slider.minValue) isIncreasing = true;
    }
}
