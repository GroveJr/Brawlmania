using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharPopup : MonoBehaviour {
    public EventSystem eventSystem;
    public SpriteRenderer portraitLeft;
    public Text nameTextLeft;
    public SpriteRenderer portraitRight;
    public Text nameTextRight;
    public GameObject pLeft;
    public GameObject pRight;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public RuntimeAnimatorController random;
    Animator anim1;
    Animator anim2;
    // Use this for initialization
    void Start()
    {
        anim1 = pLeft.GetComponent<Animator>();
        anim2 = pRight.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.selectedCharPlayer1 == "")
        {
            if (eventSystem.currentSelectedGameObject.name == "FIKom")
            {
                portraitLeft.sprite = sprite8;
                nameTextLeft.text = "JASON";
                anim1.runtimeAnimatorController = null;
            }
            else if (eventSystem.currentSelectedGameObject.name == "FPsi")
            {
                portraitLeft.sprite = sprite5;
                nameTextLeft.text = "BETSY";
                anim1.runtimeAnimatorController = null;
            }
            else if (eventSystem.currentSelectedGameObject.name == "FK")
            {
                portraitLeft.sprite = sprite4;
                nameTextLeft.text = "EDWARD";
                anim1.runtimeAnimatorController = null;
            }
            else if (eventSystem.currentSelectedGameObject.name == "FE")
            {
                portraitLeft.sprite = sprite1;
                nameTextLeft.text = "JESS";
                anim1.runtimeAnimatorController = null;
            }
            else if (eventSystem.currentSelectedGameObject.name == "FH")
            {
                portraitLeft.sprite = sprite2;
                nameTextLeft.text = "PHILLIP";
                anim1.runtimeAnimatorController = null;
            }
            else if (eventSystem.currentSelectedGameObject.name == "FT")
            {
                portraitLeft.sprite = sprite3;
                nameTextLeft.text = "RICHAD";
                anim1.runtimeAnimatorController = null;
            }
            else if (eventSystem.currentSelectedGameObject.name == "FSRD")
            {
                portraitLeft.sprite = sprite6;
                nameTextLeft.text = "LISA";
                anim1.runtimeAnimatorController = null;
            }
            else if (eventSystem.currentSelectedGameObject.name == "FTI")
            {
                portraitLeft.sprite = sprite7;
                nameTextLeft.text = "SL1MZ";
                anim1.runtimeAnimatorController = null;
            }
            else if (eventSystem.currentSelectedGameObject.name == "Random")
            {
                portraitLeft.sprite = null;
                nameTextLeft.text = "";
                anim1.runtimeAnimatorController = random as RuntimeAnimatorController;
            }
            else
            {
                portraitLeft.sprite = null;
                nameTextLeft.text = "";
                anim1.runtimeAnimatorController = null;
            }
        }

        if (GameManager.gm.selectedCharPlayer1 == "FE")
        {
            portraitLeft.sprite = sprite1;
            nameTextLeft.text = "JESS";
            anim1.runtimeAnimatorController = null;
        }
        else if(GameManager.gm.selectedCharPlayer1 == "FH")
        {
            portraitLeft.sprite = sprite2;
            nameTextLeft.text = "PHILLIP";
            anim1.runtimeAnimatorController = null;
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FT")
        {
            portraitLeft.sprite = sprite3;
            nameTextLeft.text = "RICHAD";
            anim1.runtimeAnimatorController = null;
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FK")
        {
            portraitLeft.sprite = sprite4;
            nameTextLeft.text = "EDWARD";
            anim1.runtimeAnimatorController = null;
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FPsi")
        {
            portraitLeft.sprite = sprite5;
            nameTextLeft.text = "BETSY";
            anim1.runtimeAnimatorController = null;
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FSRD")
        {
            portraitLeft.sprite = sprite6;
            nameTextLeft.text = "LISA";
            anim1.runtimeAnimatorController = null;
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FTI")
        {
            portraitLeft.sprite = sprite7;
            nameTextLeft.text = "SL1MZ";
            anim1.runtimeAnimatorController = null;
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FIKom")
        {
            portraitLeft.sprite = sprite8;
            nameTextLeft.text = "JASON";
            anim1.runtimeAnimatorController = null;
        }

        if (GameManager.gm.gameMode == "versus")
        {
            if (GameManager.gm.selectedCharPlayer2 == "FE")
            {
                portraitRight.sprite = sprite1;
                nameTextRight.text = "JESS";
                anim2.runtimeAnimatorController = null;
            }
            else if (GameManager.gm.selectedCharPlayer2 == "FH")
            {
                portraitRight.sprite = sprite2;
                nameTextRight.text = "PHILLIP";
                anim2.runtimeAnimatorController = null;
            }
            else if (GameManager.gm.selectedCharPlayer2 == "FT")
            {
                portraitRight.sprite = sprite3;
                nameTextRight.text = "RICHAD";
                anim2.runtimeAnimatorController = null;
            }
            else if (GameManager.gm.selectedCharPlayer2 == "FK")
            {
                portraitRight.sprite = sprite4;
                nameTextRight.text = "EDWARD";
                anim2.runtimeAnimatorController = null;
            }
            else if (GameManager.gm.selectedCharPlayer2 == "FPsi")
            {
                portraitRight.sprite = sprite5;
                nameTextRight.text = "BETSY";
                anim2.runtimeAnimatorController = null;
            }
            else if (GameManager.gm.selectedCharPlayer2 == "FSRD")
            {
                portraitRight.sprite = sprite6;
                nameTextRight.text = "LISA";
                anim2.runtimeAnimatorController = null;
            }
            else if (GameManager.gm.selectedCharPlayer2 == "FTI")
            {
                portraitRight.sprite = sprite7;
                nameTextRight.text = "SL1MZ";
                anim2.runtimeAnimatorController = null;
            }
            else if (GameManager.gm.selectedCharPlayer2 == "FIKom")
            {
                portraitRight.sprite = sprite8;
                nameTextRight.text = "JASON";
                anim2.runtimeAnimatorController = null;
            }

            if (GameManager.gm.selectedCharPlayer1 != "")
            {
                if (eventSystem.currentSelectedGameObject.name == "FIKom")
                {
                    portraitRight.sprite = sprite8;
                    nameTextRight.text = "JASON";
                    anim2.runtimeAnimatorController = null;
                }
                else if (eventSystem.currentSelectedGameObject.name == "FPsi")
                {
                    portraitRight.sprite = sprite5;
                    nameTextRight.text = "BETSY";
                    anim2.runtimeAnimatorController = null;
                }
                else if (eventSystem.currentSelectedGameObject.name == "FK")
                {
                    portraitRight.sprite = sprite4;
                    nameTextRight.text = "EDWARD";
                    anim2.runtimeAnimatorController = null;
                }
                else if (eventSystem.currentSelectedGameObject.name == "FE")
                {
                    portraitRight.sprite = sprite1;
                    nameTextRight.text = "JESS";
                    anim2.runtimeAnimatorController = null;
                }
                else if (eventSystem.currentSelectedGameObject.name == "FH")
                {
                    portraitRight.sprite = sprite2;
                    nameTextRight.text = "PHILLIP";
                    anim2.runtimeAnimatorController = null;
                }
                else if (eventSystem.currentSelectedGameObject.name == "FT")
                {
                    portraitRight.sprite = sprite3;
                    nameTextRight.text = "RICHAD";
                    anim2.runtimeAnimatorController = null;
                }
                else if (eventSystem.currentSelectedGameObject.name == "FSRD")
                {
                    portraitRight.sprite = sprite6;
                    nameTextRight.text = "LISA";
                    anim2.runtimeAnimatorController = null;
                }
                else if (eventSystem.currentSelectedGameObject.name == "FTI")
                {
                    portraitRight.sprite = sprite7;
                    nameTextRight.text = "SL1MZ";
                    anim2.runtimeAnimatorController = null;
                }
                else if (eventSystem.currentSelectedGameObject.name == "Random")
                {
                    portraitRight.sprite = null;
                    nameTextRight.text = "";
                    anim2.runtimeAnimatorController = random as RuntimeAnimatorController;
                }
                else
                {
                    portraitRight.sprite = null;
                    nameTextRight.text = "";
                    anim2.runtimeAnimatorController = null;
                }
            }
        }
    }
}
