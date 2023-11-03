using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAppear : MonoBehaviour
{
    public Animator animator;

    public RemoveAll RO;

    public RecordOptions RecordOptionsScript;

    public GameObject MaskModel;

    public AudioSource Audio;

    public List<GameObject> Buttons = new();

    public float imageWidthScale;
    public float imageHeightScale;
    public Sprite newImage;
    
    public string Text;
    public string BoolName;

    public bool enableDialogue;
    public bool enableAudio;
    public bool stopAudio;
    public bool animationChange;
    public bool ChangePosition;
    public bool MaskOn;
    public bool ShowImage;
    public bool changeImage;
    public bool recordChoice;

    public void Appear(){
        if(enableDialogue){
            DialogueAppear(Text);
        }
        if(enableAudio){
            PlayAudio();
        }
        if(stopAudio){
            StopAudio();
        }
        if(animationChange){
            ChangeAnimation();
        }
        if(MaskOn){
            AppearMask();
        }
        if(ShowImage){
            ChangeImage();
            RO.Image.SetActive(true);
        }
        if(changeImage){
            ChangeImage();
        }
        if(recordChoice){
            RecordOptionsScript.RecordChoice(EventSystem.current.currentSelectedGameObject.name);
        }
        foreach(GameObject btn in Buttons){
            btn.SetActive(true);
        }
    }

    public void Disappear(){
        RO.RemoveAllItems();
        Appear();
    }

    public void DialogueAppear(string text){
        RO.DialogBox.SetActive(true);
        RO.Dialog.text = text;
    }

    public void ChangeAnimation(){
        animator.SetBool(BoolName, ChangePosition);
    }

    public void AppearMask(){
        MaskModel.SetActive(true);
    }

    public void ChangeImage(){
        if(newImage != null){
            Image imageComponent = RO.Image.GetComponent<Image>();
            imageComponent.sprite = newImage;

            Transform transform = RO.Image.GetComponent<Transform>();
            transform.localScale = new Vector3(imageWidthScale, imageHeightScale, 1f);
        }
    }

    public void PlayAudio(){
        Audio.Play(0);
    }

    public void StopAudio(){
        Audio.Stop();
    }
}
