using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_ZombieIdle : State_ZombieBase
{
    
    public float DetectionRange = 7;

    public override void InitializeState(StateManager_Zombie _zombieState)
    {
        Debug.Log("Idle State initialized!");
    }

    public override void UpdateState(StateManager_Zombie _zombieState)
    {
        Vector3 playerDir = _zombieState.PlayerPos.position - _zombieState.MyPos.position;
        if (playerDir.magnitude <= DetectionRange)
            _zombieState.LoadNextState(_zombieState.chaseState);

    }
}
