using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecordOptions : MonoBehaviour
{
    public Text outputTextBox;
    [HideInInspector] public static List<string> choiceNames = new();
    [HideInInspector] public static List<string> timeOfDay = new();
    [HideInInspector] public static List<string> timeTaken = new();
    private float timerTime;
    private PauseMenuScript pauseMenu;

    void Start()
    {
        timerTime = 0f;
        pauseMenu = GetComponent<PauseMenuScript>();

        if (SceneManager.GetActiveScene().name != "FinalScreen")
        {
            choiceNames = new List<string>();
            timeOfDay = new List<string>();
            timeTaken = new List<string>();
            return;
        }

        for (int i = 0; i < choiceNames.Count; i++)
        {
            if (i == 0)
            {
                outputTextBox.text += $"Started at {timeOfDay[i]}\n";
            }
            else
            {
                outputTextBox.text += $"\n{choiceNames[i]}\n{timeOfDay[i]} after {timeTaken[i]}\n";
            }
        }
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            if (!pauseMenu.isPaused)
            {
                timerTime += Time.deltaTime;
            }
            yield return null;
        }
    }

    public void RecordChoice(string name)
    {
        // string time = DateTime.Now.ToString("T"); //24hr format
        string time = DateTime.Now.ToString("hh:mm tt").ToUpper(); // 12 hr format
        string duration = TimeSpan.FromSeconds(timerTime).ToString(@"mm\:ss\.ff");

        if (name.StartsWith("Observations")) // Means all the observation buttons won't need to have the same name in the editor.
        {
            name = "Checked observtions";
        }
        
        
        if (choiceNames.Count == 0)
        {
            outputTextBox.text += $"Started at {time}\n";
            name = "Started";
            StartCoroutine(Timer());
        }
        else
        {
            outputTextBox.text += $"\n{name}\n{time} after {duration}\n";
            timerTime = 0f;
        }

        choiceNames.Add(name);
        timeOfDay.Add(time);
        timeTaken.Add(duration);
    }

    // Put on "On Value Changed (Vector2)" on Scroll View in the final scene.
    // Put on the route button in the pause menu in the Anaphylaxis scene.
    public void ResizeTextBoxToFitContents()
    {
        outputTextBox.rectTransform.sizeDelta = new Vector2(outputTextBox.preferredWidth, outputTextBox.preferredHeight);
    }
}
