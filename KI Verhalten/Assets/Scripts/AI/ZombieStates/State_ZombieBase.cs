using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State_ZombieBase
{
    /// <summary>
    /// Gets called when a State first initialized. Basically the "Start" method of States
    /// </summary>
    /// <param name="_zombieState">Reference to Zombie Statemanager</param>
    public abstract void InitializeState(StateManager_Zombie _zombieState);

    /// <summary>
    /// Gets called in Statemanager's Update Method. States don't have their own Update because they don't derive from MonoBehaviour and to save performance 
    /// </summary>
    /// <param name="_zombieState">Reference to Zombie Statemanager</param>
    public abstract void UpdateState(StateManager_Zombie _zombieState);

    /// <summary>
    /// Each State has its own Collision Method that gets called seperately in the Zombie Statemanager
    /// </summary>
    /// <param name="_zombieState">Reference to Zombie Statemanager</param>
    public abstract void ZombieOnCollisionEnter(StateManager_Zombie _zombieState);
}
