using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerManager : MonoBehaviour {
    private Animator anim;
    public BattleManager battle;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    public void Fight()
    {
        anim.SetTrigger("Fight");
    }

    public void YouWin()
    {
        anim.SetTrigger("You Win");
    }

    public void YouLose()
    {
        anim.SetTrigger("You Lose");
    }

    public void P1Win()
    {
        anim.SetTrigger("P1 Win");
    }

    public void P2Win()
    {
        anim.SetTrigger("P2 Win");
    }

    void ActivateEvent()
    {
        battle.NextFight();
    }
}
