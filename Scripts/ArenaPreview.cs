using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArenaPreview : MonoBehaviour {
    public EventSystem eventSystem;
    public SpriteRenderer preview;
    public Text nameArena;
    public GameObject ap;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public RuntimeAnimatorController random;
    Animator anim;
    // Use this for initialization
    void Start () {
        anim = ap.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (eventSystem.currentSelectedGameObject.name == "Bundaran_R")
        {
            preview.sprite = sprite1;
            nameArena.text = "ROUNDABOUT RUMBLE";
            anim.runtimeAnimatorController = null;
        }
        else if (eventSystem.currentSelectedGameObject.name == "Gedung_M")
        {
            preview.sprite = sprite2;
            nameArena.text = "MASSACRE MADNESS";
            anim.runtimeAnimatorController = null;
        }
        else if (eventSystem.currentSelectedGameObject.name == "Hall_BC")
        {
            preview.sprite = sprite3;
            nameArena.text = "BLOODY COLISEUM";
            anim.runtimeAnimatorController = null;
        }
        else if (eventSystem.currentSelectedGameObject.name == "Lapangan_Lt8")
        {
            preview.sprite = sprite4;
            nameArena.text = "SADISTIC STADIUM";
            anim.runtimeAnimatorController = null;
        }
        else if (eventSystem.currentSelectedGameObject.name == "Gedung_Utama")
        {
            preview.sprite = sprite5;
            nameArena.text = "EVACUATION EVASION";
            anim.runtimeAnimatorController = null;
        }
        else if (eventSystem.currentSelectedGameObject.name == "Gedung_Teknik")
        {
            preview.sprite = sprite6;
            nameArena.text = "TRIUMPHANT TRIANGLE";
            anim.runtimeAnimatorController = null;
        }
        else if (eventSystem.currentSelectedGameObject.name == "Gedung_Parkir")
        {
            preview.sprite = sprite7;
            nameArena.text = "JUNKYARD JUNKIES";
            anim.runtimeAnimatorController = null;
        }
        else if (eventSystem.currentSelectedGameObject.name == "Hall_A")
        {
            preview.sprite = sprite8;
            nameArena.text = "ALLIANCE ARENA";
            anim.runtimeAnimatorController = null;
        }
        else if(eventSystem.currentSelectedGameObject.name == "Random")
        {
            preview.sprite = null;
            nameArena.text = "";
            anim.runtimeAnimatorController = random as RuntimeAnimatorController;
        }
        else
        {
            preview.sprite = null;
            nameArena.text = "";
        }
    }
}
