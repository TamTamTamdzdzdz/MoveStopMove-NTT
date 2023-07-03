using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    // Start is called before the first frame update
    public void OnEnter(Player player)
    {

    }
    public void OnExecute(Player player)
    {
        player.isMoving = false;
        player.ChangeAnim(Character.AnimationType.IDLE);
        if (player.variableJoystick.Horizontal != 0 || player.variableJoystick.Vertical != 0)
        {


            player.ChangeState(new PlayerPatrolState());


        }
        if (player.TheNearestCharacter(player.gameObject) != null)
        {
            player.ChangeState(new PlayerAttackState());
        }
    }
    public void OnExit(Player player)
    {

    }

}
