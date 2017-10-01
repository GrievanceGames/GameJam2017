﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public GameObject playerAvatar;
    public Camera mainCamera;
    public Vector3 movementVector = new Vector3(0.0f, 0.0f, 0.0f);
	public GameObject myTextGameObject;
	public Text textObjectText;
    public GameObject canvasObject;
	public bool inSign = false;
    public bool switchScene = false;
    public GameObject staticVariables;

    public int[] playerPosition = new int[] {1, 1};
    int[] invalidPositions = new int[] {12, 18, 76, 55, 56, 87, 88};

    // Use this for initialization
    void Start () {
        canvasObject = GameObject.Find("Canvas");
        myTextGameObject = GameObject.Find ("gameText");
		textObjectText.text = "Welcome to Moral Ambiguity! Please face the sign and press F.";
        playerPosition = StaticVariableStorage.instance.GetPlayerPosition();

        transform.position = mainCamera.transform.position + new Vector3(0.95f * (playerPosition[0] - 1), 0.95f * (playerPosition[1] - 1.0f),0.0f);
    }

    private void OnDestroy()
    {
        StaticVariableStorage.instance.SetPlayerPosition(playerPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (inSign == false) {

            if (Input.GetKeyDown(KeyCode.W))
            {
                playerAvatar.GetComponent<Animator>().Play("UpAvatarWalk");
                if (playerPosition[1] + 1 != 9 && ValidNewPosition(1, 1))
                {
                    movementVector.Set(0.0f, 0.95f, 0.0f);
                    playerPosition[1] += 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                playerAvatar.GetComponent<Animator>().Play("LeftAvatarWalk");
                if (playerPosition[0] - 1 != 0 && ValidNewPosition(-1, 0))
                {
                    movementVector.Set(-0.95f, 0.0f, 0.0f);
                    playerPosition[0] -= 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                playerAvatar.GetComponent<Animator>().Play("IdleAvatar");
                if (playerPosition[1] - 1 != 0 && ValidNewPosition(-1, 1))
                {
                    movementVector.Set(0.0f, -0.95f, 0.0f);
                    playerPosition[1] -= 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                playerAvatar.GetComponent<Animator>().Play("RightAvatarWalk");
                if (playerPosition[0] + 1 != 9 && ValidNewPosition(1, 0))
                {
                    movementVector.Set(0.95f, 0.0f, 0.0f);
                    playerPosition[0] += 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {

				if (playerPosition [0] == 1 && playerPosition [1] == 1) {
					textObjectText.text = "Each sign will present you with a morally challenging scenario. Press ESC to exit";
					inSign = true;
				} else if (playerPosition [0] == 1 && playerPosition [1] == 7) {
					textObjectText.text = "Hey, you're in a grocery store! \nClick F to continue or click ESC to exit";
					inSign = true;
				} else if (playerPosition [0] == 1 && playerPosition [1] == 7) {
					textObjectText.text = "Doctor! I have a question! \nClick F to continue or click ESC to exit";
					inSign = true;
				} else if (playerPosition [0] == 7 && playerPosition [1] == 5) {
					textObjectText.text = "Maybe I did.";
					inSign = true;
				} else if (playerPosition [0] == 6 && playerPosition [1] == 2) {
					textObjectText.text = "Can I ask you a trolley question? \nClick F to continue or click ESC to exit";
					inSign = true;
				} 
				}
				else {
				}
			}
		else if (Input.GetKeyDown (KeyCode.Escape)) { 
			print ("escape button clicked");
			textObjectText.text = "";
			inSign = false;
		} else {
			if (Input.GetKeyDown (KeyCode.F)) {
				textObjectText.text = "";
                SceneManager.LoadScene("TrainChooChoo");
                inSign = false;
			}
		}
    }




    void LateUpdate()
    {
        if (movementVector.x != 0.0f || movementVector.y != 0.0f)
        {
            transform.position = mainCamera.transform.position + movementVector;
            movementVector.Set(0.0f, 0.0f, 0.0f);
        }
    }

    bool ValidNewPosition(int movement, int direction)
    {
        int newX = playerPosition[0] + movement * (1 - direction);
        int newY = playerPosition[1] + movement * direction;
        for (int i = 0; i < invalidPositions.Length; i++)
        {
            if(newX == Mathf.Floor(invalidPositions[i]/10) && newY == invalidPositions[i]%10)
            {
                return false;
            }
        }

        return true;
    }

}
