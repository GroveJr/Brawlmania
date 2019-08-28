using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeManager : MonoBehaviour {
    public static ArcadeManager am;

    public float score;
    public int win = 0;
    public string arcadeName;

	void Awake () {
        MakeThisTheOnlyArcadeManager();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gm.gameMode == "arcade")
        {
            if (GameManager.gm.selectedCharPlayer1 == "FE")
            {
                if (win == 0)
                {
                    GameManager.gm.selectedCharPlayer2 = "FH";
                    GameManager.gm.selectedArena = "Gedung M";
                }
                else if (win == 1)
                {
                    GameManager.gm.selectedCharPlayer2 = "FT";
                    GameManager.gm.selectedArena = "Gedung Teknik";
                }
                else if (win == 2)
                {
                    GameManager.gm.selectedCharPlayer2 = "FK";
                    GameManager.gm.selectedArena = "Lapangan Lt8";
                }
                else if (win == 3)
                {
                    GameManager.gm.selectedCharPlayer2 = "FPsi";
                    GameManager.gm.selectedArena = "Gedung Parkir";
                }
                else if (win == 4)
                {
                    GameManager.gm.selectedCharPlayer2 = "FSRD";
                    GameManager.gm.selectedArena = "Hall A";
                }
                else if (win == 5)
                {
                    GameManager.gm.selectedCharPlayer2 = "FTI";
                    GameManager.gm.selectedArena = "Bundaran R";
                }
                else if (win == 6)
                {
                    GameManager.gm.selectedCharPlayer2 = "FIKom";
                    GameManager.gm.selectedArena = "Gedung Utama";
                }
                else if (win == 7)
                {
                    GameManager.gm.selectedCharPlayer2 = "API";
                    GameManager.gm.selectedArena = "Hall BC";
                }
            }
            else if (GameManager.gm.selectedCharPlayer1 == "FH")
            {
                if (win == 0)
                {
                    GameManager.gm.selectedCharPlayer2 = "FE";
                    GameManager.gm.selectedArena = "Hall BC";
                }
                else if (win == 1)
                {
                    GameManager.gm.selectedCharPlayer2 = "FT";
                    GameManager.gm.selectedArena = "Gedung Teknik";
                }
                else if (win == 2)
                {
                    GameManager.gm.selectedCharPlayer2 = "FK";
                    GameManager.gm.selectedArena = "Lapangan Lt8";
                }
                else if (win == 3)
                {
                    GameManager.gm.selectedCharPlayer2 = "FPsi";
                    GameManager.gm.selectedArena = "Gedung Parkir";
                }
                else if (win == 4)
                {
                    GameManager.gm.selectedCharPlayer2 = "FSRD";
                    GameManager.gm.selectedArena = "Hall A";
                }
                else if (win == 5)
                {
                    GameManager.gm.selectedCharPlayer2 = "FTI";
                    GameManager.gm.selectedArena = "Bundaran R";
                }
                else if (win == 6)
                {
                    GameManager.gm.selectedCharPlayer2 = "FIKom";
                    GameManager.gm.selectedArena = "Gedung Utama";
                }
                else if (win == 7)
                {
                    GameManager.gm.selectedCharPlayer2 = "API";
                    GameManager.gm.selectedArena = "Gedung M";
                }
            }
            else if (GameManager.gm.selectedCharPlayer1 == "FT")
            {
                if (win == 0)
                {
                    GameManager.gm.selectedCharPlayer2 = "FE";
                    GameManager.gm.selectedArena = "Hall BC";
                }
                else if (win == 1)
                {
                    GameManager.gm.selectedCharPlayer2 = "FH";
                    GameManager.gm.selectedArena = "Gedung M";
                }
                else if (win == 2)
                {
                    GameManager.gm.selectedCharPlayer2 = "FK";
                    GameManager.gm.selectedArena = "Lapangan Lt8";
                }
                else if (win == 3)
                {
                    GameManager.gm.selectedCharPlayer2 = "FPsi";
                    GameManager.gm.selectedArena = "Gedung Parkir";
                }
                else if (win == 4)
                {
                    GameManager.gm.selectedCharPlayer2 = "FSRD";
                    GameManager.gm.selectedArena = "Hall A";
                }
                else if (win == 5)
                {
                    GameManager.gm.selectedCharPlayer2 = "FTI";
                    GameManager.gm.selectedArena = "Bundaran R";
                }
                else if (win == 6)
                {
                    GameManager.gm.selectedCharPlayer2 = "FIKom";
                    GameManager.gm.selectedArena = "Gedung Utama";
                }
                else if (win == 7)
                {
                    GameManager.gm.selectedCharPlayer2 = "API";
                    GameManager.gm.selectedArena = "Gedung Teknik";
                }
            }
            else if (GameManager.gm.selectedCharPlayer1 == "FK")
            {
                if (win == 0)
                {
                    GameManager.gm.selectedCharPlayer2 = "FE";
                    GameManager.gm.selectedArena = "Hall BC";
                }
                else if (win == 1)
                {
                    GameManager.gm.selectedCharPlayer2 = "FH";
                    GameManager.gm.selectedArena = "Gedung M";
                }
                else if (win == 2)
                {
                    GameManager.gm.selectedCharPlayer2 = "FT";
                    GameManager.gm.selectedArena = "Gedung Teknik";
                }
                else if (win == 3)
                {
                    GameManager.gm.selectedCharPlayer2 = "FPsi";
                    GameManager.gm.selectedArena = "Gedung Parkir";
                }
                else if (win == 4)
                {
                    GameManager.gm.selectedCharPlayer2 = "FSRD";
                    GameManager.gm.selectedArena = "Hall A";
                }
                else if (win == 5)
                {
                    GameManager.gm.selectedCharPlayer2 = "FTI";
                    GameManager.gm.selectedArena = "Bundaran R";
                }
                else if (win == 6)
                {
                    GameManager.gm.selectedCharPlayer2 = "FIKom";
                    GameManager.gm.selectedArena = "Gedung Utama";
                }
                else if (win == 7)
                {
                    GameManager.gm.selectedCharPlayer2 = "API";
                    GameManager.gm.selectedArena = "Lapangan Lt8";
                }
            }
            else if (GameManager.gm.selectedCharPlayer1 == "FPsi")
            {
                if (win == 0)
                {
                    GameManager.gm.selectedCharPlayer2 = "FE";
                    GameManager.gm.selectedArena = "Hall BC";
                }
                else if (win == 1)
                {
                    GameManager.gm.selectedCharPlayer2 = "FH";
                    GameManager.gm.selectedArena = "Gedung M";
                }
                else if (win == 2)
                {
                    GameManager.gm.selectedCharPlayer2 = "FT";
                    GameManager.gm.selectedArena = "Gedung Teknik";
                }
                else if (win == 3)
                {
                    GameManager.gm.selectedCharPlayer2 = "FK";
                    GameManager.gm.selectedArena = "Lapangan Lt8";
                }
                else if (win == 4)
                {
                    GameManager.gm.selectedCharPlayer2 = "FSRD";
                    GameManager.gm.selectedArena = "Hall A";
                }
                else if (win == 5)
                {
                    GameManager.gm.selectedCharPlayer2 = "FTI";
                    GameManager.gm.selectedArena = "Bundaran R";
                }
                else if (win == 6)
                {
                    GameManager.gm.selectedCharPlayer2 = "FIKom";
                    GameManager.gm.selectedArena = "Gedung Utama";
                }
                else if (win == 7)
                {
                    GameManager.gm.selectedCharPlayer2 = "API";
                    GameManager.gm.selectedArena = "Gedung Parkir";
                }
            }
            else if (GameManager.gm.selectedCharPlayer1 == "FSRD")
            {
                if (win == 0)
                {
                    GameManager.gm.selectedCharPlayer2 = "FE";
                    GameManager.gm.selectedArena = "Hall BC";
                }
                else if (win == 1)
                {
                    GameManager.gm.selectedCharPlayer2 = "FH";
                    GameManager.gm.selectedArena = "Gedung M";
                }
                else if (win == 2)
                {
                    GameManager.gm.selectedCharPlayer2 = "FT";
                    GameManager.gm.selectedArena = "Gedung Teknik";
                }
                else if (win == 3)
                {
                    GameManager.gm.selectedCharPlayer2 = "FK";
                    GameManager.gm.selectedArena = "Lapangan Lt8";
                }
                else if (win == 4)
                {
                    GameManager.gm.selectedCharPlayer2 = "FPsi";
                    GameManager.gm.selectedArena = "Gedung Parkir";
                }
                else if (win == 5)
                {
                    GameManager.gm.selectedCharPlayer2 = "FTI";
                    GameManager.gm.selectedArena = "Bundaran R";
                }
                else if (win == 6)
                {
                    GameManager.gm.selectedCharPlayer2 = "FIKom";
                    GameManager.gm.selectedArena = "Gedung Utama";
                }
                else if (win == 7)
                {
                    GameManager.gm.selectedCharPlayer2 = "API";
                    GameManager.gm.selectedArena = "Hall A";
                }
            }
            else if (GameManager.gm.selectedCharPlayer1 == "FTI")
            {
                if (win == 0)
                {
                    GameManager.gm.selectedCharPlayer2 = "FE";
                    GameManager.gm.selectedArena = "Hall BC";
                }
                else if (win == 1)
                {
                    GameManager.gm.selectedCharPlayer2 = "FH";
                    GameManager.gm.selectedArena = "Gedung M";
                }
                else if (win == 2)
                {
                    GameManager.gm.selectedCharPlayer2 = "FT";
                    GameManager.gm.selectedArena = "Gedung Teknik";
                }
                else if (win == 3)
                {
                    GameManager.gm.selectedCharPlayer2 = "FK";
                    GameManager.gm.selectedArena = "Lapangan Lt8";
                }
                else if (win == 4)
                {
                    GameManager.gm.selectedCharPlayer2 = "FPsi";
                    GameManager.gm.selectedArena = "Gedung Parkir";
                }
                else if (win == 5)
                {
                    GameManager.gm.selectedCharPlayer2 = "FSRD";
                    GameManager.gm.selectedArena = "Hall A";
                }
                else if (win == 6)
                {
                    GameManager.gm.selectedCharPlayer2 = "FIKom";
                    GameManager.gm.selectedArena = "Gedung Utama";
                }
                else if (win == 7)
                {
                    GameManager.gm.selectedCharPlayer2 = "API";
                    GameManager.gm.selectedArena = "Bundaran R";
                }
            }
            else
            {
                if (win == 0)
                {
                    GameManager.gm.selectedCharPlayer2 = "FE";
                    GameManager.gm.selectedArena = "Hall BC";
                }
                else if (win == 1)
                {
                    GameManager.gm.selectedCharPlayer2 = "FH";
                    GameManager.gm.selectedArena = "Gedung M";
                }
                else if (win == 2)
                {
                    GameManager.gm.selectedCharPlayer2 = "FT";
                    GameManager.gm.selectedArena = "Gedung Teknik";
                }
                else if (win == 3)
                {
                    GameManager.gm.selectedCharPlayer2 = "FK";
                    GameManager.gm.selectedArena = "Lapangan Lt8";
                }
                else if (win == 4)
                {
                    GameManager.gm.selectedCharPlayer2 = "FPsi";
                    GameManager.gm.selectedArena = "Gedung Parkir";
                }
                else if (win == 5)
                {
                    GameManager.gm.selectedCharPlayer2 = "FSRD";
                    GameManager.gm.selectedArena = "Hall A";
                }
                else if (win == 6)
                {
                    GameManager.gm.selectedCharPlayer2 = "FTI";
                    GameManager.gm.selectedArena = "Bundaran R";
                }
                else if (win == 7)
                {
                    GameManager.gm.selectedCharPlayer2 = "API";
                    GameManager.gm.selectedArena = "Gedung Utama";
                }
            }
        }
    }

    void MakeThisTheOnlyArcadeManager()
    {
        if (am == null)
        {
            DontDestroyOnLoad(gameObject);
            am = this;
        }
        else
        {
            if (am != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
