using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickOpt1 : MonoBehaviour {

    public Button optBtn1;
    public Button optBtn2;
    public Button hiddenBtn;

    public Sprite sprite; // Drag your original sprite here
    public Sprite sprite1; // Drag your first option result here
    public Sprite sprite2; // Drag your second option result
    public Sprite hiddenSprite; // Drag your hidden option result
    public SpriteRenderer spriteRenderer;

    public Text message;
    private string message1;
    private string message2;
    private string message3;

    // Use this for initialization
    void Start () {
        //Button 1
        optBtn1 = GetComponent<Button>();
        optBtn1.onClick.AddListener(Button1);

        //Button2
        optBtn2 = GetComponent<Button>();
        optBtn2.onClick.AddListener(Button2);

        //Hidden Button
        hiddenBtn = GetComponent<Button>();
        hiddenBtn.onClick.AddListener(HiddenButton);

        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = sprite;
    }

    void Button1()
    {
        print("Option1 was selected");
        TaskOnClick(sprite1);
    }
    void Button2()
    {
        print("Option2 was selected");
        TaskOnClick(sprite2);
    }
    void HiddenButton()
    {
<<<<<<< HEAD
        print("HiddenOption was selected");
        TaskOnClick(hiddenSprite);
=======
        Debug.Log("Return to Main Menu From 1");
        SceneManager.LoadScene("MainMenu");
		// PlayerMovement.playerPosition = previousPosition.position;
>>>>>>> d71b7faa30cfab13ea4190982f1e8979f14cd440
    }

    void TaskOnClick(Sprite spriteChange)
    {
        print("switch to: " + spriteChange.name);
       
        if (spriteRenderer.sprite == sprite)
        {
            print(spriteChange);
            spriteRenderer.sprite = spriteChange;
        }
        else
        {

            spriteRenderer.sprite = sprite;
        }

        optBtn1.gameObject.SetActive(false);
        optBtn2.gameObject.SetActive(false);
        hiddenBtn.gameObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }

    void SceneChoose()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "TrainChooChoo")
        {
            message1 = "You didn't do anything. Five people died. One person was saved.";
            message2 = "You flipped the switch. One person died. Five people were saved.";
            message3 = "Congratulations! You went looking for a better way. You alerted the train conductor in time and everyone was saved.";
        }
        else if (scene.name == "SubmarineHatch")
        {
            message1 = "opt1";
            message2 = "opt2";
            message3 = "hidden";
        }
        else if (scene.name == "GroceryStore")
        {
            message1 = "opt1";
            message2 = "opt2";
            message3 = "hidden";
        }
        else if (scene.name == "LastScene")
        {
            message1 = "Give the button to someone else.";
            message2 = "Don't tell anyone about the button.";
            message3 = "You press the button yourself.";
        }

    }
    void MessageChange(int btn)
    {
        if (btn == 1)//option2
        {
            message.text = message1;
        }
        else if (btn == 2)//option2
        {
            message.text = message2;
        }
        else if (btn == 3)//hidden message
        {
            message.text = message3;
        }
    } 

}
