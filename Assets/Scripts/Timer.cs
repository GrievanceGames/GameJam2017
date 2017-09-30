using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public float waitTime = 1f;
    public Text text;
    float timer;
    float timeAct;
    public SpriteRenderer background;
    public Button opt1;
    public Button opt2;
    bool timerActive = true;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        timeAct = 15f - timer;
        if (timerActive)
        {
            if (Math.Round(timeAct) == 10)
            {
                text.color = Color.yellow;
                text.fontSize = 20;
            }
            else if (Math.Round(timeAct) == 5)
            {
                text.color = new Color32(255, 65, 0, 255);
                text.fontSize = 35;
            }
            else if (Math.Round(timeAct) == 3)
            {
                text.color = Color.red;
                text.fontSize = 50;
            }


            if (timeAct > 0)
            {
                text.text = "";
                text.text = "" + Math.Round(timeAct);
            }
            else if (Math.Round(timeAct) == 0)
            {
                text.fontSize = 20;
                text.text = "You did nothing.";
                background.color = Color.black;
                opt1.gameObject.SetActive(false);
                opt2.gameObject.SetActive(false);
                timerActive = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {

            SceneManager.LoadScene("MainMenu");
        }
    
    }

}
