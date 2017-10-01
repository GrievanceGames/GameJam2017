using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScreen : MonoBehaviour {

	public Text TextObject;
	public int hiddenButtons;

	// Use this for initialization
	void Start () {
		hiddenButtons = StaticVariableStorage.instance.GetHiddenFound();
		TextObject.text = "The Garden is not impressed with your morality. You found " + hiddenButtons + " alternative options in the world that is not binary. The Garden will let you leave. For now. Press ESC to exit.";

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
