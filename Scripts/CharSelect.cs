using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour {
    int random;

    public void SelectChar()
    {
        if(GameManager.gm.gameMode == "arcade" || GameManager.gm.gameMode == "practice")
        {
            if (gameObject.name == "FIKom")
                GameManager.gm.selectedCharPlayer1 = "FIKom";
            else if (gameObject.name == "FPsi")
                GameManager.gm.selectedCharPlayer1 = "FPsi";
            else if (gameObject.name == "FK")
                GameManager.gm.selectedCharPlayer1 = "FK";
            else if (gameObject.name == "FE")
                GameManager.gm.selectedCharPlayer1 = "FE";
            else if (gameObject.name == "FT")
                GameManager.gm.selectedCharPlayer1 = "FT";
            else if (gameObject.name == "FH")
                GameManager.gm.selectedCharPlayer1 = "FH";
            else if (gameObject.name == "FSRD")
                GameManager.gm.selectedCharPlayer1 = "FSRD";
            else if (gameObject.name == "FTI")
                GameManager.gm.selectedCharPlayer1 = "FTI";
            else if (gameObject.name == "Random")
            {
                random = Random.Range(1, 8);
                if (random == 1)
                    GameManager.gm.selectedCharPlayer1 = "FE";
                else if (random == 2)
                    GameManager.gm.selectedCharPlayer1 = "FH";
                else if (random == 3)
                    GameManager.gm.selectedCharPlayer1 = "FT";
                else if (random == 4)
                    GameManager.gm.selectedCharPlayer1 = "FK";
                else if (random == 5)
                    GameManager.gm.selectedCharPlayer1 = "FPsi";
                else if (random == 6)
                    GameManager.gm.selectedCharPlayer1 = "FSRD";
                else if (random == 7)
                    GameManager.gm.selectedCharPlayer1 = "FTI";
                else if (random == 8)
                    GameManager.gm.selectedCharPlayer1 = "FIKom";
            }
        }
        else if (GameManager.gm.gameMode=="versus")
        {
            if (GameManager.gm.selectedCharPlayer1 == "")
            {
                if (gameObject.name == "FIKom")
                    GameManager.gm.selectedCharPlayer1 = "FIKom";
                else if (gameObject.name == "FPsi")
                    GameManager.gm.selectedCharPlayer1 = "FPsi";
                else if (gameObject.name == "FK")
                    GameManager.gm.selectedCharPlayer1 = "FK";
                else if (gameObject.name == "FE")
                    GameManager.gm.selectedCharPlayer1 = "FE";
                else if (gameObject.name == "FT")
                    GameManager.gm.selectedCharPlayer1 = "FT";
                else if (gameObject.name == "FH")
                    GameManager.gm.selectedCharPlayer1 = "FH";
                else if (gameObject.name == "FSRD")
                    GameManager.gm.selectedCharPlayer1 = "FSRD";
                else if (gameObject.name == "FTI")
                    GameManager.gm.selectedCharPlayer1 = "FTI";
                else if (gameObject.name == "Random")
                {
                    random = Random.Range(1, 8);
                    if (random == 1)
                        GameManager.gm.selectedCharPlayer1 = "FE";
                    else if (random == 2)
                        GameManager.gm.selectedCharPlayer1 = "FH";
                    else if (random == 3)
                        GameManager.gm.selectedCharPlayer1 = "FT";
                    else if (random == 4)
                        GameManager.gm.selectedCharPlayer1 = "FK";
                    else if (random == 5)
                        GameManager.gm.selectedCharPlayer1 = "FPsi";
                    else if (random == 6)
                        GameManager.gm.selectedCharPlayer1 = "FSRD";
                    else if (random == 7)
                        GameManager.gm.selectedCharPlayer1 = "FTI";
                    else if (random == 8)
                        GameManager.gm.selectedCharPlayer1 = "FIKom";
                }
            }
            else if (GameManager.gm.selectedCharPlayer1 != "")
            {
                if (gameObject.name == "FIKom")
                    GameManager.gm.selectedCharPlayer2 = "FIKom";
                else if (gameObject.name == "FPsi")
                    GameManager.gm.selectedCharPlayer2 = "FPsi";
                else if (gameObject.name == "FK")
                    GameManager.gm.selectedCharPlayer2 = "FK";
                else if (gameObject.name == "FE")
                    GameManager.gm.selectedCharPlayer2 = "FE";
                else if (gameObject.name == "FT")
                    GameManager.gm.selectedCharPlayer2 = "FT";
                else if (gameObject.name == "FH")
                    GameManager.gm.selectedCharPlayer2 = "FH";
                else if (gameObject.name == "FSRD")
                    GameManager.gm.selectedCharPlayer2 = "FSRD";
                else if (gameObject.name == "FTI")
                    GameManager.gm.selectedCharPlayer2 = "FTI";
                else if (gameObject.name == "Random")
                {
                    random = Random.Range(1, 8);
                    if (random == 1)
                        GameManager.gm.selectedCharPlayer2 = "FE";
                    else if (random == 2)
                        GameManager.gm.selectedCharPlayer2 = "FH";
                    else if (random == 3)
                        GameManager.gm.selectedCharPlayer2 = "FT";
                    else if (random == 4)
                        GameManager.gm.selectedCharPlayer2 = "FK";
                    else if (random == 5)
                        GameManager.gm.selectedCharPlayer2 = "FPsi";
                    else if (random == 6)
                        GameManager.gm.selectedCharPlayer2 = "FSRD";
                    else if (random == 7)
                        GameManager.gm.selectedCharPlayer2 = "FTI";
                    else if (random == 8)
                        GameManager.gm.selectedCharPlayer2 = "FIKom";
                }
            }
        }
    }        
}
