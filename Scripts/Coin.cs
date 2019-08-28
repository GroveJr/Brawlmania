using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    Rigidbody2D rb2d;
    public Fighter controller;
    private AudioSource source;
    GameObject fighter;
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        controller = fighter.GetComponent<Fighter>();
    }
	
	// Update is called once per frame
	void Update () {
        if (controller.facingRight == true)
            rb2d.velocity = new Vector2(7f, 0f);
        else if (controller.facingRight == false)
            rb2d.velocity = new Vector2(-7f, 0f);

        Destroy(gameObject, 0.2f);
    }

    void Awake()
    {
        fighter = GameObject.FindGameObjectWithTag("FE");
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("SfxVolume");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject)
            Destroy(gameObject, 0f);
    }
}
