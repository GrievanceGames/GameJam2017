﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticVariableStorage : MonoBehaviour {

    public static StaticVariableStorage instance = null;
    private static int[] playerPositionArray = new int[2];
	private static string gameText;
    private static int stagesCompleted = 0;

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
        playerPositionArray = newPlayerPosition;
    }

    public int[] GetPlayerPosition()
    {
        return (playerPositionArray);
    }

	public void SetGameText(string newGameText) {
		gameText = newGameText;
	}

	public string GetGameText() {
		return gameText;
	}

    public void SetStageCompleted()
    {
        stagesCompleted++;
    }

    public int GetStagesCompleted()
    {
        return (stagesCompleted);
    }

}
