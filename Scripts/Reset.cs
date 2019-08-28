using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetGame()
    {
        GameManager.gm.gameMode = "";
        GameManager.gm.userAmount = 0;
        GameManager.gm.selectedCharPlayer1 = "";
        GameManager.gm.selectedCharPlayer2 = "";
        GameManager.gm.selectedArena = "";
        GameManager.gm.roundAmount = 0;
        GameManager.gm.selectedRoundTime = 0;
        ArcadeManager.am.score = 0;
        ArcadeManager.am.win = 0;
    }

    public void ResetArena()
    {
        GameManager.gm.selectedArena = "";
    }

    public void ResetChar()
    {
        GameManager.gm.selectedCharPlayer1 = "";
        GameManager.gm.selectedCharPlayer2 = "";
    }

    public void ResetRound()
    {
        GameManager.gm.roundAmount = 0;
    }
}
