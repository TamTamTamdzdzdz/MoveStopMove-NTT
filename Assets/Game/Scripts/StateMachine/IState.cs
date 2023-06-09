using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter(AIBot t);
    void OnExecute(AIBot t);
    void OnExit(AIBot t);
}
