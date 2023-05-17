using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text label;

    private int[] speeds = new int[5];
    private int speedIndex = 0;
    public int speed = 1;

    private void Awake()
    {
        speeds = new int[5];
        speeds[0] = 1;
        speeds[1] = 2;
        speeds[2] = 5;
        speeds[3] = 10;
        speeds[4] = 25;
    }

    public void ChangeSpeed(int value)
    {
        if (speedIndex + value > 4)
        {
            return;
        }
        
        if (speedIndex + value < 0)
        {
            return;
        }
        
        speedIndex += value;
        speed = speeds[speedIndex];
        
        label.text = "x" + speed.ToString();
        Time.timeScale = speed;
    }
}
