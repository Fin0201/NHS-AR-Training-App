using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject pauseMenuCanvas;
    public GameObject helpCanvas;
    public GameObject routesCanvas;
    [HideInInspector]
    public bool isPaused = false;

    public void ShowPauseMenu()
    {
        mainCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(true);
        isPaused = true;
    }

    public void HidePauseMenu()
    {
        mainCanvas.SetActive(true);
        pauseMenuCanvas.SetActive(false);
        isPaused = false;
    }

    public void ShowHelpCanvas()
    {
        helpCanvas.SetActive(true);
        pauseMenuCanvas.SetActive(false);
    }

    public void HideHelpCanvas()
    {
        helpCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(true);
    }

    public void ShowRoutesCanvas()
    {
        routesCanvas.SetActive(true);
        pauseMenuCanvas.SetActive(false);
    }

    public void HideRoutesCanvas()
    {
        routesCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(true);
    }
}
