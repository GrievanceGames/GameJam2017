using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HiddenButton : MonoBehaviour
{

    public Button optBtn;
    Timer Timer = new Timer();

    // Use this for initialization
    void Start()
    {
        optBtn = GetComponent<Button>();
        optBtn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        print("Go to MainMenu");
        Timer.text.fontSize = 10;
        Timer.text.text = "Congratulations! You've found the hidden third option.";

        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("GardenOfMorality");
        }
    }
}
