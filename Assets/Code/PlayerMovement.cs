using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject playerAvatar;
    public Camera mainCamera;
    public Vector3 movementVector = new Vector3(0.0f, 0.0f, 0.0f);
    int[] playerPosition = new int[] {1, 1};
    int[] invalidPositions = new int[] {12, 18, 76};
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && playerPosition[1] + 1 != 9 && ValidNewPosition(1, 1))
        {
            movementVector.Set(0.0f, 0.95f, 0.0f);
            playerPosition[1] += 1;
            print("W key was pressed");
        }
        else if (Input.GetKeyDown(KeyCode.A) && playerPosition[0] -1 != 0 && ValidNewPosition(-1, 0))
        {
            movementVector.Set(-0.95f, 0.0f, 0.0f);
            playerPosition[0] -= 1;
            print("A key was pressed");
        }
        else if (Input.GetKeyDown(KeyCode.S) && playerPosition[1] - 1 != 0 && ValidNewPosition(-1, 1))
        {
            movementVector.Set(0.0f, -0.95f, 0.0f);
            playerPosition[1] -= 1;
            print("S key was pressed");
        }
        else if (Input.GetKeyDown(KeyCode.D) && playerPosition[0] + 1 != 9 && ValidNewPosition(1, 0))
        {
            movementVector.Set(0.95f, 0.0f, 0.0f);
            playerPosition[0] += 1;
            print("D  key was pressed");
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            print("F  key was pressed");
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
