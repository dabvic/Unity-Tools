using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.StateMachine
{
    /// <summary>
    /// Transitions are a combination of one or more decisions and destination states whether or not these transitions are true or false. An example of a transition could be "_if an enemy gets in range, transition to the Shooting state_".
    /// </summary>
    [System.Serializable]
    public class Transition 
    {
        /// this transition's decision
        public Condition Decision;
        /// the state to transition to if this Decision returns true
        public string TrueState;
        /// the state to transition to if this Decision returns false
        public string FalseState;
    }
}
