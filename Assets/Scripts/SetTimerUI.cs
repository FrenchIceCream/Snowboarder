using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTimerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] timerText;
    void Start()
    { 
        TimerSaver timerSaver  = FindFirstObjectByType<TimerSaver>();
        if (timerSaver == null)
            return;
        Debug.Log("timerSaver");
        for (int i = 0; i < timerText.Length; i++)
        {
            float time = timerSaver.GetTimer(i);
            Debug.Log(timerSaver.GetTimer(i));
            if (time == 0)
                continue;
            int seconds = (int)time / 1000;
            int milliseconds = (int) time % 1000;
            timerText[i].text = string.Format("{0:00}:{1:000}", seconds, milliseconds);
        }
    }
}
