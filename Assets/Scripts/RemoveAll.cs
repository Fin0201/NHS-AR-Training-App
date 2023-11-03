using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveAll : MonoBehaviour
{
    public List<GameObject> Buttons = new();
    public GameObject Image;
    public GameObject DialogBox;
    public Text Dialog;

    public void RemoveAllItems(){
        foreach(GameObject btn in Buttons){
            btn.SetActive(false);
        }
        DialogBox.SetActive(false);
        Image.SetActive(false);
    }
}
