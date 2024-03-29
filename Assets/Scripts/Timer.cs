﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    public Text counterText;
    public float seconds, minutes;

    void Start()
    {
        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        counterText.text = "Time: " + minutes.ToString("00") + " : " + seconds.ToString("00");
    }
}
