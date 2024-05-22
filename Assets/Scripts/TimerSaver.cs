using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerSaver : MonoBehaviour
{
    ShowTimerText showTimerTextComponent;
    void Awake()
    {
        if (FindObjectsOfType<TimerSaver>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            ShowTimerText showTimerText = FindAnyObjectByType<ShowTimerText>();
            if (showTimerText != null)
            {
                showTimerTextComponent = showTimerText;
            }
            DontDestroyOnLoad(gameObject);
            StartTimer();   
            SceneManager.activeSceneChanged += StartTimerOnSceneChaned;
        }
    }

    float[] timers = new float[3];
    float current = 0;
    bool shouldTick;
    public void StopTimer(int level)
    {
        if (level < 0 || level >= timers.Length)
            return;        
        shouldTick = false;
        
        if (current != 0 && current < timers[level] || timers[level] == 0)
        {
            timers[level] = current;
        }

        current = 0;
    }

    void StartTimerOnSceneChaned(Scene cur, Scene next)
    {
        current = 0;
        StartTimer();
    }

    public void StartTimer()
    {
        ShowTimerText showTimerText = FindAnyObjectByType<ShowTimerText>();
        if (showTimerText != null)
        {
            showTimerTextComponent = showTimerText;
            shouldTick = true;
        }
        NulliFyTime();
    }

    public float GetTimer(int level)
    {
        return timers[level];
    }

    void Update()
    {
        if (shouldTick)
        {
            current += Time.deltaTime * 1000;
            if (showTimerTextComponent != null)
                showTimerTextComponent.SetTimerText(current);
        }
    }

    public void NulliFyTime()
    {
        current = 0;
    }
}
