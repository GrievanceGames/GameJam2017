using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leave : MonoBehaviour
{
    public bool finalDilema = false;
    // Update is called once per frame
    void Update()
    {
        //print("update");
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("F pressed");

            print(finalDilema);
            if(finalDilema)
            {
                SceneManager.LoadScene("endscreen");
            }
            else
            {
                StaticVariableStorage.instance.SetStageCompleted();
                SceneManager.LoadScene("GardenOfMorality");
            }
        }
    }
}