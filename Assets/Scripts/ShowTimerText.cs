using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTimerText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public void SetTimerText(float time)
    {
        int seconds = (int)time / 1000;
        int milliseconds = (int) time % 1000;
        timerText.text = string.Format("{0:00}:{1:000}", seconds, milliseconds);
    }
}
