using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_ZombieChase : State_ZombieBase
{
    public override void InitializeState(StateManager_Zombie _zombieState)
    {
        Debug.Log("Chase State initialized!");
    }

    public override void ZombieOnCollisionEnter(StateManager_Zombie _zombieState, Collision _collision)
    {

    }

    public override void UpdateState(StateManager_Zombie _zombieState)
    {
        ChaseWalkCycle(_zombieState);
    }

    private void ChaseWalkCycle(StateManager_Zombie _zombieState)
    {
        Vector3 playerDir = _zombieState.PlayerPos.position - _zombieState.MyPos.position;
        _zombieState.RB.AddForce(playerDir.normalized * _zombieState.MoveSpeed);
        if (playerDir.magnitude >= 8)
            _zombieState.LoadNextState(_zombieState.idleState);
    }
}
