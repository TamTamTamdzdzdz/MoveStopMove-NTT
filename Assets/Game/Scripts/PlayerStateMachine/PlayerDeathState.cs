using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
    private float m_DeathTime = 0.15f;
    public void OnEnter(Player player)
    {
        player.ChangeAnim(Character.AnimationType.DEAD);
        
    }
    public void OnExecute(Player player)
    {
        player.rb.velocity=Vector3.zero;
        m_DeathTime-=Time.deltaTime;
        if (m_DeathTime < 0)
        {
            player.ChangeState(new PlayerIdleState());
        }
    }
    public void OnExit(Player player)
    {

    }
}
