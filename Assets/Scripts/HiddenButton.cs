using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HiddenButton : MonoBehaviour
{

    public Button optBtn;

    // Use this for initialization
    void Start()
    {
        optBtn = GetComponent<Button>();
        optBtn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        print("Go to MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
}
