using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject playerAvatar;
    public Camera mainCamera;
    public Vector3 movementVector = new Vector3(0.0f, 0.0f, 0.0f);

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            movementVector.Set(0.0f, 1.65f, 0.0f);
            print("W key was pressed");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            movementVector.Set(-1.65f, 0.0f, 0.0f);
            print("A key was pressed");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            movementVector.Set(0.0f, -1.65f, 0.0f);
            print("S key was pressed");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            movementVector.Set(1.65f, 0.0f, 0.0f);
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
            print(playerAvatar.transform.position);
            movementVector.Set(0.0f, 0.0f, 0.0f);
            print(playerAvatar.transform.position);
        }
    }

}
