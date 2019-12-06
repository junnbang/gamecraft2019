﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public int timer = 60;
    public Text timerText;

    private bool isTimerStarted;
    // Start is called before the first frame update
    void Start()
    {
        isTimerStarted = false;
        timerText.text = "60 seconds";
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.isGameStarted && !isTimerStarted) {
            InvokeRepeating("decreaseTimer", 1.0f, 1.0f);
            isTimerStarted = true;
        }
        //decrease timer value in GUI

    }

    void decreaseTimer() {
        if (timer > 0)
        {
            timer -= 1;
            timerText.text = timer + " seconds";
            Debug.Log("timer =" + timer);
        }
        else
        {
            isTimerStarted = false;
            Manager.Instance.isGameStarted = false;
            CancelInvoke();
        }
    }
}
