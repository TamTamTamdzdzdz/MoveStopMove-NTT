using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerState
{
    void OnEnter(Player t);
    void OnExecute(Player t);
    void OnExit(Player t);
}