using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameMode()
    {
        if (gameObject.name == "ArcadeButton")
        {
            GameManager.gm.gameMode = "arcade";
            GameManager.gm.userAmount = 1;
        }
        else if (gameObject.name == "VersusButton")
            GameManager.gm.gameMode = "versus";
        else if (gameObject.name == "PracticeButton")
        {
            GameManager.gm.gameMode = "practice";
            GameManager.gm.userAmount = 1;
        }
    }

    public void VersusMode()
    {
        if (gameObject.name == "VsAIButton")
            GameManager.gm.userAmount = 1;
        else if (gameObject.name == "VsPlayerButton")
            GameManager.gm.userAmount = 2;
    }
}
