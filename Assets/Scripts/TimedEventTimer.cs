using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEventTimer : MonoBehaviour
{
    public GameObject continueButton;
    public Dictionary<string, Coroutine> activeTimers;
    private PauseMenuScript pauseMenu;

    void Start()
    {
        activeTimers = new Dictionary<string, Coroutine>();
        pauseMenu = GetComponent<PauseMenuScript>();
    }

    private IEnumerator Timer(float timerSeconds, Action returnToMethod)
    {
        float elapsedTime = 0f;
        while (elapsedTime < timerSeconds)
        {
            if (!pauseMenu.isPaused)
            {
                elapsedTime += Time.deltaTime;
            }
            yield return null;
        }
        activeTimers.Remove(returnToMethod.Method.Name);
        returnToMethod();
    }

    // The IEnumerator has to be called and stopped from this script or else Unity will throw a hissy fit.
    [HideInInspector]
    public void StartTimer(float timerSeconds, Action returnToMethod)
    {
        Coroutine TimerInstance = StartCoroutine(Timer(timerSeconds, returnToMethod));
        activeTimers[returnToMethod.Method.Name] = TimerInstance;
    }

    [HideInInspector]
    public void StopTimer(Coroutine Timer, string timerDictKey)
    {
        activeTimers.Remove(timerDictKey);
        StopCoroutine(Timer);
    }
}
