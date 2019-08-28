using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug : MonoBehaviour {
    public Button newHighscore, noHighscore;
	// Use this for initialization
	void Start () {
        newHighscore.onClick.AddListener(debugNewHighscore);
        noHighscore.onClick.AddListener(debugNoHighscore);
	}

    void debugNewHighscore()
    {
        ArcadeManager.am.win = 6;
        ArcadeManager.am.score = 3.00f;
    }

    void debugNoHighscore()
    {
        ArcadeManager.am.win = 6;
    }
}
