using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    
    private Vector3 target;
    private float timeMoving;
    public void OnEnter(AIBot aIBot)
    {
        timeMoving = Random.Range(3f, 5f);
        target = aIBot.RandomPoint(Random.Range(3f,5f));
        aIBot.ChangeAnim(Character.AnimationType.RUN);
    }
    public void OnExecute(AIBot aIBot)
    {
        timeMoving -= Time.deltaTime;
        aIBot.transform.LookAt(new Vector3(target.x,aIBot.transform.position.y,target.z));
        aIBot.agent.SetDestination(target);
        aIBot.isMoving = true;
        if (Vector3.Distance(aIBot.transform.position, target) < 0.1f ||timeMoving<0)
        {
            aIBot.ChangeState(new IdleState());
        }
        
    }
    public void OnExit(AIBot aIBot)
    {

    }
}
