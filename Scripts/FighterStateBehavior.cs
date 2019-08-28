using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStateBehavior : StateMachineBehaviour {
    public FighterStates behaviorState;
    protected Fighter fighter;

    override public void OnStateEnter(Animator anim, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fighter == null)
        {
            fighter = anim.gameObject.GetComponent<Fighter>();
        }

        fighter.currentState = behaviorState;

        if (fighter.player == Fighter.PlayerType.AI)
        {
            if (fighter.currentState == FighterStates.ATTACK || fighter.currentState == FighterStates.TAKE_HIT)
            {
                fighter.aiDelay = Time.time + fighter.timeDelay;
                fighter.anim.SetFloat("Delay", fighter.aiDelay);
            }
        }
    }

    override public void OnStateUpdate(Animator anim, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fighter.player == Fighter.PlayerType.AI)
        {
            if (fighter.currentState == FighterStates.WALK)
            {
                if (fighter.transform.position.x > fighter.opponent.transform.position.x)
                {
                    fighter.body.velocity = new Vector2(-fighter.speed, 0);
                    if (fighter.facingRight == true)
                        fighter.Flip();
                }
                else if (fighter.transform.position.x < fighter.opponent.transform.position.x)
                {
                    fighter.body.velocity = new Vector2(fighter.speed, 0);
                    if (fighter.facingRight == false)
                        fighter.Flip();
                }
            }

            if (fighter.currentState == FighterStates.DEFEND)
            {
                fighter.aiDelay = Time.time + fighter.timeDelay;
                fighter.anim.SetFloat("Delay", fighter.aiDelay);
            }

            if (fighter.gameObject.tag == "FPsi")
            {
                if (Mathf.Abs(fighter.transform.position.y - fighter.opponent.transform.position.y) > 0.1f)
                {
                    fighter.body.velocity = new Vector2(0, -fighter.speed);
                }
            }
        }
    }
}
