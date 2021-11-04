using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_ZombieIdle : State_ZombieBase
{
    
    [SerializeField]
    private float walkTimer;    //Time delay of randomizing target points
    private Vector3 walkDirection;  //Random target point to walk towards
    

    public override void InitializeState(StateManager_Zombie _zombieState)
    {
        Debug.Log("Idle State initialized!");
    }

    public override void ZombieOnCollisionEnter(StateManager_Zombie _zombieState, Collision _collision)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(StateManager_Zombie _zombieState)
    {
        IdleWalkCycle(_zombieState);
        //Provisoric code for Playerdetection. Subject to change (wanted to make a viewrange in a specific range and angle and if player is seen change state)
        Vector3 playerDir = _zombieState.PlayerPos.position - _zombieState.MyPos.position;
        if (playerDir.magnitude <= _zombieState.DetectionRange)     //Make a Vector from own position to Player's position and check it's length.
            _zombieState.LoadNextState(_zombieState.chaseState);    //If the Vector is below Detectionrange > Transition to Chase State
    }

    private void IdleWalkCycle(StateManager_Zombie _zombieState)
    {
        if (walkTimer > 0)
            walkTimer -= Time.deltaTime;
        else if (walkTimer <= 0)
        {
            walkTimer = 3;
            walkDirection = _zombieState.Waypoints[Random.Range(0, _zombieState.Waypoints.Length)].normalized;
            //walkDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));   //Determine a new point the AI walks towards every 3 seconds
        }

        _zombieState.RB.AddForce(walkDirection * _zombieState.MoveSpeed);


        //_zombieState.transform.rotation = Quaternion.Euler(_zombieState.transform.rotation.x, _zombieState.transform.rotation.x + _zombieState.transform.rotation.z, _zombieState.transform.rotation.z);
    }
}
