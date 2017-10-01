using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariableStorage : MonoBehaviour {

    public static StaticVariableStorage instance = null;
    private static int[] playerPositioinArray = new int[2];

    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
            print("Started New Position Script");
            int[] initialPlayerPosition = new int[] { 1, 1 };
            SetPlayerPosition(initialPlayerPosition);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerPosition(int[] newPlayerPosition)
    {
        playerPositioinArray = newPlayerPosition;
    }

    public int[] GetPlayerPosition()
    {
        return (playerPositioinArray);
    }


}
