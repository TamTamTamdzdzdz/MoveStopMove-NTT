using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    float time;
    public void OnEnter(AIBot aIBot)
    {
        
        time = Random.Range(1f, 3f);
        aIBot.ChangeAnim(Character.AnimationType.IDLE);
    }
    public void OnExecute(AIBot aIBot)
    {
        time-=Time.deltaTime;
        aIBot.isMoving = false;
        if (time < 0f)
        {
            aIBot.ChangeState(new PatrolState());
        }
        if(aIBot.TheNearestCharacter(aIBot.gameObject)!=null)
        {
            aIBot.ChangeState(new AttackState());
            Debug.Log("aiBot change attack state");
        }
    }
    public void OnExit(AIBot aIBot)
    {

    }
}
