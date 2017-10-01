using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SingleButton : MonoBehaviour
{

    public Button optBtn;
    public Button optOther;
    public Button optHidden;

    public Sprite sprite; // Drag your original sprite here
    public Sprite sprite1; // Drag your first option result here
    public SpriteRenderer spriteRenderer;

    public Text timer;
    public Text message;
    private string messageTxt;
    // Use this for initialization
    void Start()
    {
        //Button 1
        optBtn = GetComponent<Button>();
        optBtn.onClick.AddListener(Button1);

        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = sprite;
    }

    void Button1()
    {
        print("Option was selected");
        TaskOnClick(sprite1);
    }

    void TaskOnClick(Sprite spriteChange)
    {
        print("switch to: " + spriteChange.name);
        SceneChoose();
        print(messageTxt);
        if (spriteRenderer.sprite == sprite)
        {
            print(spriteChange);
            spriteRenderer.sprite = spriteChange;

            message.text = messageTxt;

            optBtn.gameObject.SetActive(false);
            optOther.gameObject.SetActive(false);
            optHidden.gameObject.SetActive(false);
            timer.gameObject.SetActive(false);
        }
    }

    void SceneChoose()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "TrainChooChoo")
        {
            if (optBtn.name == "Option1")
            {
                messageTxt = "You didn't do anything. Five people died. One person was saved.";
            }
            else if (optBtn.name == "Option2")
            {
                messageTxt = "You flipped the switch. One person died. Five people were saved.";
            }
            else if (optBtn.name == "HiddenOption")
            {
                messageTxt = "Congratulations! You went looking for a better way. You alerted the train conductor in time and everyone was saved.";
            }
        }
        else if (scene.name == "SubmarineHatch")
        {
            if (optBtn.name == "Option1")
            {
                messageTxt = "Option1";
            }
            else if (optBtn.name == "Option2")
            {
                messageTxt = "Option2";
            }
            else if (optBtn.name == "HiddenOption")
            {
                messageTxt = "Hidden";
            }
        }
        else if (scene.name == "GroceryStore")
        {
            if (optBtn.name == "Option1")
            {
                messageTxt = "Option1";
            }
            else if (optBtn.name == "Option2")
            {
                messageTxt = "Option2";
            }
            else if (optBtn.name == "HiddenOption")
            {
                messageTxt = "Hidden";
            }
        }
        else if (scene.name == "LastScene")
        {
            if (optBtn.name == "Option1")
            {
                messageTxt = "Give the button to someone else. The responsibility has been lifted off your shoulders.";
            }
            else if (optBtn.name == "Option2")
            {
                messageTxt = "You don't tell anyone about the button. The world continues on as normal.";
            }
            else if (optBtn.name == "HiddenOption")
            {
                messageTxt = "Interesting... You pressed the button yourself.";
            }
            
        }

    }

}
