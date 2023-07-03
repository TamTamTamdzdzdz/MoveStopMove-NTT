using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPatrolState : PlayerState
{
    public void OnEnter(Player player)
    {

    }
    public void OnExecute(Player player)
    {
        player.Moving();
        if (player.variableJoystick.Horizontal == 0 && player.variableJoystick.Vertical == 0)
        {
            player.ChangeState(new PlayerIdleState());
        }
    }
    public void OnExit(Player player)
    {

    }
}
