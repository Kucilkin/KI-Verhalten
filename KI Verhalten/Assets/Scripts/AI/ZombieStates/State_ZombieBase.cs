using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State_ZombieBase
{
    public abstract void InitializeState(StateManager_Zombie _zombieState);

    public abstract void UpdateState(StateManager_Zombie _zombieState);

}
