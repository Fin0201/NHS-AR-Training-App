using UnityEngine;

public class ButtonManagerSingleton : MonoBehaviour
{
    public static ButtonManagerSingleton Instance {get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
