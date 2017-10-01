using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour {

    public Button playButton;
    public Button dontPlayButton;

	// Use this for initialization
	void Start () {
        playButton.onClick.AddListener(PlayButtonPressed);
        dontPlayButton.onClick.AddListener(DontPlayButtonPressed);
    }
	
	void PlayButtonPressed()
    {
        print("Play");
        SceneManager.LoadScene("GardenOfMorality");
    }

    void DontPlayButtonPressed()
    {
        print("Dont Play");
        Application.Quit();
    }
}
