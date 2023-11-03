using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TimedEventController : MonoBehaviour
{
    public float startOxygenTimerWithTime;
    public bool stopOxygenTimer;
    public string oxygenDialogueText; // Put on start button not stop

    private readonly Type scriptType = typeof(TimedEventController);
    private TimedEventTimer timedEventTimer;
    private RecordOptions recordOptions;
    private ButtonAppear buttonAppear;

    
    void Start()
    {
        timedEventTimer = ButtonManagerSingleton.Instance.GetComponent<TimedEventTimer>();
        recordOptions = ButtonManagerSingleton.Instance.GetComponent<RecordOptions>();
        buttonAppear = GetComponent<ButtonAppear>();
    }

    private void StartTimers(string methodName, float startTimerWithTime)
    {
        if (startTimerWithTime > 0f && !timedEventTimer.activeTimers.TryGetValue(methodName, out _))
        {
            Action timerEndMethod = (Action)Delegate.CreateDelegate(typeof(Action), this, scriptType.GetMethod(methodName, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic));
            timedEventTimer.StartTimer(startTimerWithTime, timerEndMethod);
        }
    }

    private void StopTimers(string methodName, bool stopTimer)
    {
        if (stopTimer && timedEventTimer.activeTimers.TryGetValue(methodName, out Coroutine Timer))
        {
            timedEventTimer.StopTimer(Timer, methodName);
        }
    }

    // Use this on butons
    public void MakeThisScriptDoThings()
    {
        string methodName = "EndOfOxygenTimer";
        StartTimers(methodName, startOxygenTimerWithTime);
        StopTimers(methodName, stopOxygenTimer);
    }

    private void ShowMessage(string displayText)
    {
        List<GameObject> tempButtons = new(buttonAppear.Buttons);
        buttonAppear.Buttons = new List<GameObject> { timedEventTimer.continueButton };
        buttonAppear.Disappear();
        buttonAppear.Buttons = new(tempButtons);

        buttonAppear.DialogueAppear(displayText);
    }

    private void EndOfOxygenTimer()
    {
        ShowMessage(oxygenDialogueText);
        recordOptions.RecordChoice("Stats dropped 88% after 2 minutes");
    }
}
