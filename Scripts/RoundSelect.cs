using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectRound()
    {
        if (gameObject.name == "1")
            GameManager.gm.roundAmount = 1;
        else if (gameObject.name == "3")
            GameManager.gm.roundAmount = 3;
    }
}
