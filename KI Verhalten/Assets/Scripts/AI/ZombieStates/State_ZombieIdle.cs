using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_ZombieIdle : State_ZombieBase
{

    public float DetectionRange = 7;
    [SerializeField]
    private float walkTimer;
    private Vector3 walkDirection;
    

    public override void InitializeState(StateManager_Zombie _zombieState)
    {
        Debug.Log("Idle State initialized!");
    }

    public override void ZombieOnCollisionEnter(StateManager_Zombie _zombieState)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(StateManager_Zombie _zombieState)
    {
        IdleWalkCycle(_zombieState);
        //Provisoric code for Playerdetection. Subject to change (wanted to make a viewrange in a specific range and angle and if player is seen change state)
        Vector3 playerDir = _zombieState.PlayerPos.position - _zombieState.MyPos.position;
        if (playerDir.magnitude <= DetectionRange)
            _zombieState.LoadNextState(_zombieState.chaseState);
    }

    private void IdleWalkCycle(StateManager_Zombie _zombieState)
    {
        if (walkTimer > 0)
            walkTimer -= Time.deltaTime;
        else if (walkTimer <= 0)
        {
            walkTimer = 3;
            walkDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        }

        _zombieState.RB.AddForce(walkDirection * _zombieState.MoveSpeed);
        //_zombieState.transform.rotation = Quaternion.Euler(_zombieState.transform.rotation.x, _zombieState.transform.rotation.x + _zombieState.transform.rotation.z, _zombieState.transform.rotation.z);
    }
}
