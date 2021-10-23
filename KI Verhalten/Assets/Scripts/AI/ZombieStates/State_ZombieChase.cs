using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_ZombieChase : State_ZombieBase
{
    public override void InitializeState(StateManager_Zombie _zombieState)
    {
        Debug.Log("Chase State initialized!");
    }

    public override void UpdateState(StateManager_Zombie _zombieState)
    {
        throw new System.NotImplementedException();
    }
}
