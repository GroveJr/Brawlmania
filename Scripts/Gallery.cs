using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gallery : MonoBehaviour {
    public SpriteRenderer portrait;
    public Text charName, dob, fac, quote, kombo1, kombo2, kombo3;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Profile()
    {
        if (gameObject.name == "FK")
        {
            portrait.sprite = sprite4;
            charName.text = "NAME		: EDWARD";
            dob.text = "DOB		: 27/11/1997";
            fac.text = "FACULTY	: MEDICAL";
            quote.text = "“I’LL TEAR YOU APART! LIMB FROM LIMB.”";
            kombo1.text = "KOMBO 1 PUNCH2, PUNCH1";
            kombo2.text = "KOMBO 2 PUNCH2, PUNCH2, PUNCH2, PUNCH2";
            kombo3.text = "KOMBO 3 KICK2, PUNCH1";
        }
        else if (gameObject.name == "FIKom")
        {
            portrait.sprite = sprite8;
            charName.text = "NAME		: JASON";
            dob.text = "DOB		: 18/03/1998";
            fac.text = "FACULTY	: COMMUNICATION";
            quote.text = "“I’LL LET MY FISTS DO THE TALKING!”";
            kombo1.text = "KOMBO 1 PUNCH1, PUNCH1, PUNCH2";
            kombo2.text = "KOMBO 2 PUNCH2, PUNCH1";
            kombo3.text = "KOMBO 3 PUNCH1, PUNCH2, PUNCH1, PUNCH2";
        }
        else if (gameObject.name == "FPsi")
        {
            portrait.sprite = sprite5;
            charName.text = "NAME		: BETSY";
            dob.text = "DOB		: 16/09/1997";
            fac.text = "FACULTY	: PSYCHOLOGY";
            quote.text = "“THE PERFECT COMBINATION OF MIND AND MAGIC.”";
            kombo1.text = "KOMBO 1 PUNCH1, PUNCH2";
            kombo2.text = "KOMBO 2 PUNCH2, PUNCH1";
            kombo3.text = null;
        }
        else if (gameObject.name == "FE")
        {
            portrait.sprite = sprite1;
            charName.text = "NAME		: JESS";
            dob.text = "DOB		: 07/09/1997";
            fac.text = "FACULTY	: ECONOMICS";
            quote.text = "“EVERYBODY’S GOT A PRICE.”";
            kombo1.text = "KOMBO 1 PUNCH1, PUNCH2, PUNCH2, PUNCH2";
            kombo2.text = "KOMBO 2 PUNCH2, PUNCH1";
            kombo3.text = "KOMBO 3 PUNCH1, PUNCH2, PUNCH1";
        }
        else if (gameObject.name == "FT")
        {
            portrait.sprite = sprite3;
            charName.text = "NAME		: RICHAD";
            dob.text = "DOB		: 07/09/1997";
            fac.text = "FACULTY	: ENGINEERING";
            quote.text = "“GENIUS BY BIRTH, LAZY BY CHOICE.”";
            kombo1.text = "KOMBO 1 PUNCH1, PUNCH2";
            kombo2.text = "KOMBO 2 KICK2, PUNCH2";
            kombo3.text = "KOMBO 3 KICK1, PUNCH2";
        }
        else if (gameObject.name == "FH")
        {
            portrait.sprite = sprite2;
            charName.text = "NAME		: PHILLIP";
            dob.text = "DOB		: 24/04/1997";
            fac.text = "FACULTY	: LAW";
            quote.text = "“I FIGHT FOR TRUTH AND JUSTICE.”";
            kombo1.text = "KOMBO 1 PUNCH1, PUNCH2, PUNCH1";
            kombo2.text = "KOMBO 2 KICK1, KICK2, KICK1";
            kombo3.text = null;
        }
        else if (gameObject.name == "FSRD")
        {
            portrait.sprite = sprite6;
            charName.text = "NAME		: LISA";
            dob.text = "DOB		: 06/03/1997";
            fac.text = "FACULTY	: ARTS AND DESIGN";
            quote.text = "“YOU CAN'T SPELL PAINT WITHOUT PAIN.”";
            kombo1.text = "KOMBO 1 PUNCH2, PUNCH1, PUNCH2";
            kombo2.text = "KOMBO 2 PUNCH1, PUNCH2";
            kombo3.text = "KOMBO 3 KICK2, PUNCH1, PUNCH1";
        }
        else if (gameObject.name == "FTI")
        {
            portrait.sprite = sprite7;
            charName.text = "NAME		: SL1MZ";
            dob.text = "DOB		: 17/06/1998";
            fac.text = "FACULTY	: INFORMATION TECHNOLOGY";
            quote.text = "“CHECK, SL1MZ IS ONLINE.”";
            kombo1.text = "KOMBO 1 PUNCH1+PUNCH2";
            kombo2.text = "KOMBO 2 PUNCH1, KICK2, PUNCH1";
            kombo3.text = "KOMBO 3 KICK1, PUNCH1+PUNCH2, PUNCH1+PUNCH2";
        }
    }
}
