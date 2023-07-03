using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private float attackTime = 3f;
    // Start is called before the first frame update
    public void OnEnter(Player player)
    {
        attackTime = 0f;
    }
    public void OnExecute(Player player) 
    {
        attackTime-=Time.deltaTime;
        if (player.TheNearestCharacter(player.gameObject) == null)
        {
            player.ChangeState(new PlayerIdleState());
        }
        else if(attackTime < 0) 
        {
            player.Attack();
            attackTime = 3f;
        }
        if (player.variableJoystick.Horizontal != 0 || player.variableJoystick.Vertical != 0)
        {


            player.ChangeState(new PlayerPatrolState());


        }
    }
    public void OnExit(Player player)
    {

    }
}
