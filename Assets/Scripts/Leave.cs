using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leave : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //print("update");
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("F pressed");
            SceneManager.LoadScene("MainMenu");
        }
    }
}