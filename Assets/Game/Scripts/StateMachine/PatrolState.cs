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
        target = new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f))+aIBot.transform.position;
        aIBot.ChangeAnim(Character.AnimationType.RUN);
    }
    public void OnExecute(AIBot aIBot)
    {
        timeMoving -= Time.deltaTime;
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
