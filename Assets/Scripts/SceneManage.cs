using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneManage: MonoBehaviour
{
    void Start()
    {
        _ = DateTime.Now; // Keep this in. DateTime.Now apparently causes a lagspike the first time it is used on android. havihng it here will get it out of the way as soon as the program starts.
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name);
    }
    
    public void ExitApp()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
