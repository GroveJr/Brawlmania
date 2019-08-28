using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBoss : MonoBehaviour {
    Rigidbody2D rb2d;
    public Fighter controller;
    private AudioSource source;
    GameObject fighter;
    bool returning = false;
    float boomerangTimer;
    // Use this for initialization
    void Start()
    {
        boomerangTimer = 0.0f;
        rb2d = GetComponent<Rigidbody2D>();
        controller = fighter.GetComponent<Fighter>();
    }

    // Update is called once per frame
    void Update()
    {
        boomerangTimer += Time.deltaTime;

        if (boomerangTimer >= 0.5)
        {
            returning = true;
        }

        if (controller.facingRight == true)
        {
            if (!returning)
            {
                transform.Rotate(Vector3.forward * 45);
                rb2d.velocity = new Vector2(9f, 0f);
            }
            else
            {
                transform.Rotate(Vector3.forward * -45);
                rb2d.velocity = new Vector2(-9f, 0f);
            }
        }
        else if (controller.facingRight == false)
        {
            if (!returning)
            {
                transform.Rotate(Vector3.forward * -45);
                rb2d.velocity = new Vector2(-9f, 0f);
            }
            else
            {
                transform.Rotate(Vector3.forward * 45);
                rb2d.velocity = new Vector2(9f, 0f);
            }
        }

        Destroy(gameObject, 0.97f);
    }

    void Awake()
    {
        fighter = GameObject.Find("Player 2");
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("SfxVolume");
    }
}
