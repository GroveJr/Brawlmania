using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectTime()
    {
        if (gameObject.name == "30")
            GameManager.gm.selectedRoundTime = 30;
        else if (gameObject.name == "60")
            GameManager.gm.selectedRoundTime = 60;
        else if (gameObject.name == "99")
            GameManager.gm.selectedRoundTime = 99;
    }
}
