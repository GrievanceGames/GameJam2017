using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickOpt1 : MonoBehaviour {

    public Button optBtn;

    // Use this for initialization
    void Start () {
        optBtn = GetComponent<Button>();
        optBtn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Return to Main Menu From 1");
        SceneManager.LoadScene("MainMenu");
		// PlayerMovement.playerPosition = previousPosition.position;
    }
}
