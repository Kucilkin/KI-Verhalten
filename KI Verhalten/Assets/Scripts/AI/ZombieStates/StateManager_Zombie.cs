using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager_Zombie : MonoBehaviour
{

    public Rigidbody RB;
    public Transform PlayerPos;
    public Transform MyPos;
    public float MoveSpeed;
    public float DetectionRange;


    public State_ZombieBase currState;  //Current State the Entity will be in

    //Creating an instance of every State the AI can be in
    public State_ZombieIdle idleState = new State_ZombieIdle();
    public State_ZombieChase chaseState = new State_ZombieChase();
    public State_ZombieDead deadState = new State_ZombieDead();


    void Start()
    {
        RB = GetComponent<Rigidbody>();
        MyPos = GetComponent<Transform>();
        currState = idleState;  //The Idle State will be the first State the AI enters. From there it will continue to chain into different states
        currState.InitializeState(this);    //Execute the first State's Initializing Method at the beginning
    }

    private void OnCollisionEnter(Collision collision)
    {
        currState.ZombieOnCollisionEnter(this, collision);     //Only the current state's Collision Method will be called 
    }

    void Update()
    {
        currState.UpdateState(this);    //Only the current state's Update Method will be called
    }

    /// <summary>
    /// Transition to following state
    /// </summary>
    /// <param name="nextState">Next State that should be executed</param>
    public void LoadNextState(State_ZombieBase nextState)
    {
        currState = nextState;      //Following state will now be the current state
        currState.InitializeState(this);    //Instantly execute the next State's Initializing Method
    }
}
