using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSelect : MonoBehaviour {
    int random;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectArena()
    {
        if (gameObject.name == "Bundaran_R")
            GameManager.gm.selectedArena = "Bundaran R";
        else if (gameObject.name == "Gedung_M")
            GameManager.gm.selectedArena = "Gedung M";
        else if (gameObject.name == "Hall_BC")
            GameManager.gm.selectedArena = "Hall BC";
        else if (gameObject.name == "Lapangan_Lt8")
            GameManager.gm.selectedArena = "Lapangan Lt8";
        else if (gameObject.name == "Gedung_Utama")
            GameManager.gm.selectedArena = "Gedung Utama";
        else if (gameObject.name == "Gedung_Teknik")
            GameManager.gm.selectedArena = "Gedung Teknik";
        else if (gameObject.name == "Gedung_Parkir")
            GameManager.gm.selectedArena = "Gedung Parkir";
        else if (gameObject.name == "Hall_A")
            GameManager.gm.selectedArena = "Hall A";
        else if (gameObject.name == "Random")
        {
            random = Random.Range(1, 8);
            if (random == 1)
                GameManager.gm.selectedArena = "Bundaran R";
            else if (random == 2)
                GameManager.gm.selectedArena = "Gedung M";
            else if (random == 3)
                GameManager.gm.selectedArena = "Hall BC";
            else if (random == 4)
                GameManager.gm.selectedArena = "Lapangan Lt8";
            else if (random == 5)
                GameManager.gm.selectedArena = "Gedung Utama";
            else if (random == 6)
                GameManager.gm.selectedArena = "Gedung Teknik";
            else if (random == 7)
                GameManager.gm.selectedArena = "Gedung Parkir";
            else if (random == 8)
                GameManager.gm.selectedArena = "Hall A";
        }
    }
}
