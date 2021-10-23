using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager_Zombie : MonoBehaviour
{
    public Transform PlayerPos;
    public Transform MyPos;

    public State_ZombieBase currState;  //Current State the Entity will be in

    //Creating an instance of every State the AI can be in
    public State_ZombieIdle idleState = new State_ZombieIdle();
    public State_ZombieChase chaseState = new State_ZombieChase();
    public State_ZombieDead deadState = new State_ZombieDead();


    void Start()
    {
        MyPos = this.GetComponent<Transform>();
        currState = idleState;  //The Idle State will be the first State the AI enters. From there it will continue to chain into different states
        currState.InitializeState(this);
    }

    void Update()
    {
        currState.UpdateState(this);
    }

    public void LoadNextState(State_ZombieBase nextState)
    {
        currState = nextState;
        currState.InitializeState(this);
    }
}
