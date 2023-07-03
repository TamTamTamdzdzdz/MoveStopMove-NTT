using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private float attackTime;
    public void OnEnter(AIBot aIBot)
    {
        attackTime = 0;
    }
    public void OnExecute(AIBot aIBot)
    {
        attackTime-=Time.deltaTime;
        if(aIBot.TheNearestCharacter(aIBot.gameObject) == null)
        {
            Debug.Log("aiBot change from attack to idle");
            aIBot.ChangeState(new IdleState());
        }
        else if(attackTime < 0) 
        {
            Debug.Log("aiBot attack");
            aIBot.Attack();
            attackTime = 3f;
        }
    }
    public void OnExit(AIBot aIBot)
    {

    }
}
