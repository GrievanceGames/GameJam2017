using System.Collections;
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

    public GameObject finalAvatarOne;
    public GameObject finalAvatarTwo;

    public int[] playerPosition = new int[] {1, 1};
    int[] invalidPositions = new int[] {12, 18, 76, 55, 56, 87, 88, 63};
    bool[] activeScenes = new bool[] { true, true, true, true };
    int activeSign = -1;

    // Use this for initialization
    void Start () {
        canvasObject = GameObject.Find("Canvas");
        myTextGameObject = GameObject.Find ("gameText");
		textObjectText.text = "Welcome to Moral Ambiguity! Please face the sign and press F.";
        playerPosition = StaticVariableStorage.instance.GetPlayerPosition();
		textObjectText.text = StaticVariableStorage.instance.GetGameText();

        transform.position = mainCamera.transform.position + new Vector3(0.95f * (playerPosition[0] - 1), 0.95f * (playerPosition[1] - 1.0f),0.0f);


        //When all but final scene completed
        if (StaticVariableStorage.instance.GetStagesCompleted() == 3)
        {
            print("VICTORY!");
            invalidPositions = new int[] { 12, 18, 76, 55, 56, 87, 88, 63, 48, 58 };
            finalAvatarOne.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            finalAvatarTwo.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }

    private void OnDestroy()
    {
        StaticVariableStorage.instance.SetPlayerPosition(playerPosition);
		StaticVariableStorage.instance.SetGameText(textObjectText.text);
    }

    // Update is called once per frame
    void Update()
	{
		if (inSign == false) {

			if (Input.GetKeyDown (KeyCode.W)) {
				playerAvatar.GetComponent<Animator> ().Play ("UpAvatarWalk");
				if (playerPosition [1] + 1 != 9 && ValidNewPosition (1, 1)) {
					movementVector.Set (0.0f, 0.95f, 0.0f);
					playerPosition [1] += 1;
				}
			} else if (Input.GetKeyDown (KeyCode.A)) {
				playerAvatar.GetComponent<Animator> ().Play ("LeftAvatarWalk");
				if (playerPosition [0] - 1 != 0 && ValidNewPosition (-1, 0)) {
					movementVector.Set (-0.95f, 0.0f, 0.0f);
					playerPosition [0] -= 1;
				}
			} else if (Input.GetKeyDown (KeyCode.S)) {
				playerAvatar.GetComponent<Animator> ().Play ("IdleAvatar");
				if (playerPosition [1] - 1 != 0 && ValidNewPosition (-1, 1)) {
					movementVector.Set (0.0f, -0.95f, 0.0f);
					playerPosition [1] -= 1;
				}
			} else if (Input.GetKeyDown (KeyCode.D)) {
				playerAvatar.GetComponent<Animator> ().Play ("RightAvatarWalk");
				if (playerPosition [0] + 1 != 9 && ValidNewPosition (1, 0)) {
					movementVector.Set (0.95f, 0.0f, 0.0f);
					playerPosition [0] += 1;
				}
			} else if (Input.GetKeyDown (KeyCode.F)) {
				if (playerPosition [0] == 1 && playerPosition [1] == 1) {
					textObjectText.text = "Each sign will present you with a morally challenging scenario. Press ESC to exit";
					inSign = true;
                    activeSign = 0;
				} else if (playerPosition [0] == 1 && playerPosition [1] == 7 && !StaticVariableStorage.instance.GetSceneEntered(1)) {
					textObjectText.text = "Hey, you're in a grocery store! \nClick F to continue or click ESC to exit";
					inSign = true;
                    activeSign = 1;
                } else if (playerPosition [0] == 7 && playerPosition [1] == 5 && !StaticVariableStorage.instance.GetSceneEntered(2)) {
					textObjectText.text = "Doctor! I have a question! \nClick F to continue or click ESC to exit";
					inSign = true;
                    activeSign = 2;
                } else if (playerPosition [0] == 6 && playerPosition [1] == 2 && !StaticVariableStorage.instance.GetSceneEntered(3)) {
					textObjectText.text = "Can I ask you a trolley question? \nClick F to continue or click ESC to exit";
					inSign = true;
                    activeSign = 3;
                } else {
				}
			}
		}else {
			if (Input.GetKeyDown (KeyCode.Escape)) { 
				textObjectText.text = "";
				inSign = false;
			} else if (Input.GetKeyDown (KeyCode.F)) {
				textObjectText.text = "";
                inSign = false;
                StaticVariableStorage.instance.SetSceneEntered(activeSign);
                SceneManager.LoadScene ("TrainChooChoo");
                    
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
