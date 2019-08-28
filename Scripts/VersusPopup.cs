using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VersusPopup : MonoBehaviour {
    public SpriteRenderer portraitLeft;
    public Text nameTextLeft;
    public SpriteRenderer portraitRight;
    public Text nameTextRight;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(ToFight());

        //Player 1
        if (GameManager.gm.selectedCharPlayer1 == "FIKom")
        {
            portraitLeft.sprite = sprite8;
            nameTextLeft.text = "JASON";
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FPsi")
        {
            portraitLeft.sprite = sprite5;
            nameTextLeft.text = "BETSY";
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FK")
        {
            portraitLeft.sprite = sprite4;
            nameTextLeft.text = "EDWARD";
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FE")
        {
            portraitLeft.sprite = sprite1;
            nameTextLeft.text = "JESS";
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FT")
        {
            portraitLeft.sprite = sprite3;
            nameTextLeft.text = "RICHAD";
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FH")
        {
            portraitLeft.sprite = sprite2;
            nameTextLeft.text = "PHILLIP";
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FSRD")
        {
            portraitLeft.sprite = sprite6;
            nameTextLeft.text = "LISA";
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FTI")
        {
            portraitLeft.sprite = sprite7;
            nameTextLeft.text = "SL1MZ";
        }

        //Player 2
        if (GameManager.gm.selectedCharPlayer2 == "FIKom")
        {
            portraitRight.sprite = sprite8;
            nameTextRight.text = "JASON";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FPsi")
        {
            portraitRight.sprite = sprite5;
            nameTextRight.text = "BETSY";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FK")
        {
            portraitRight.sprite = sprite4;
            nameTextRight.text = "EDWARD";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FE")
        {
            portraitRight.sprite = sprite1;
            nameTextRight.text = "JESS";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FT")
        {
            portraitRight.sprite = sprite3;
            nameTextRight.text = "RICHAD";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FH")
        {
            portraitRight.sprite = sprite2;
            nameTextRight.text = "PHILLIP";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FSRD")
        {
            portraitRight.sprite = sprite6;
            nameTextRight.text = "LISA";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FTI")
        {
            portraitRight.sprite = sprite7;
            nameTextRight.text = "SL1MZ";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "API")
        {
            portraitRight.sprite = sprite9;
            nameTextRight.text = "NERO";
        }
    }
	
	IEnumerator ToFight () {
        yield return new WaitForSeconds(3);
        if (GameManager.gm.selectedArena == "Bundaran R")
        {
            SceneManager.LoadScene(7);
        }
        else if (GameManager.gm.selectedArena == "Gedung M")
        {
            SceneManager.LoadScene(8);
        }
        else if (GameManager.gm.selectedArena == "Hall BC")
        {
            SceneManager.LoadScene(9);
        }
        else if (GameManager.gm.selectedArena == "Lapangan Lt8")
        {
            SceneManager.LoadScene(10);
        }
        else if (GameManager.gm.selectedArena == "Gedung Utama")
        {
            SceneManager.LoadScene(11);
        }
        else if (GameManager.gm.selectedArena == "Gedung Teknik")
        {
            SceneManager.LoadScene(12);
        }
        else if (GameManager.gm.selectedArena == "Gedung Parkir")
        {
            SceneManager.LoadScene(13);
        }
        else if (GameManager.gm.selectedArena == "Hall A")
        {
            SceneManager.LoadScene(14);
        }
    }
}
