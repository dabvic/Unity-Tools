using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.StateMachine
{
    /// <summary>
    /// The class is responsible from going from one state to the other based on the defined transitions. It's basically just a collection of states, and it's where you'll link all the actions, decisions, states and transitions together.
    /// </summary>
    public class StateMachine : MonoBehaviour
    {
        /// the collection of states
        public List<State> States;
        /// whether or not this brain is active
        public bool stateMachineActive = true;
        /// this brain's current state
        public State CurrentState { get; protected set; }

        /// the time spent in the current state
        [ReadOnly]
        public float timeInThisState;
        [ReadOnly]
        /// the current target
        public Transform Target;

        protected Condition[] conditions;

        /// <summary>
        /// On awake we set our brain for all states
        /// </summary>
        protected virtual void Awake()
        {
            foreach (State state in States)
            {
                state.SetBrain(this);
            }
            conditions = this.gameObject.GetComponents<Condition>();
        }

        /// <summary>
        /// On Start we set our first state
        /// </summary>
        protected virtual void Start()
        {
            if (States.Count > 0)
            {
                CurrentState = States[0];
            }            
        }

        /// <summary>
        /// Every frame we update our current state
        /// </summary>
        protected virtual void Update()
        {
            if (!stateMachineActive || CurrentState == null)
            {
                return;
            }
            CurrentState.UpdateState();
            timeInThisState += Time.deltaTime;
        }

        /// <summary>
        /// Transitions to the specified state, trigger exit and enter states events
        /// </summary>
        /// <param name="newStateName"></param>
        public virtual void TransitionToState(string newStateName)
        {
            if (newStateName != CurrentState.StateName)
            {
                CurrentState.ExitState();
                OnExitState();

                CurrentState = FindState(newStateName);
                if (CurrentState != null)
                {
                    CurrentState.EnterState();
                }                
            }
        }
        
        /// <summary>
        /// Resets time counter when exiting a state
        /// </summary>
        protected virtual void OnExitState()
        {
            timeInThisState = 0f;
        }

        /// <summary>
        /// Initializes all decisions
        /// </summary>
        protected virtual void InitializeDecisions()
        {
            foreach(Condition decision in conditions)
            {
                decision.Initialization();
            }
        }

        /// <summary>
        /// Returns a state based on the specified state name
        /// </summary>
        /// <param name="stateName"></param>
        /// <returns></returns>
        protected State FindState(string stateName)
        {
            foreach (State state in States)
            {
                if (state.StateName == stateName)
                {
                    return state;
                }
            }
            Debug.LogError("You're trying to transition to state '" + stateName + "' in " + this.gameObject.name + "'s State Machine, but no state of this name exists. Make sure your states are named properly, and that your transitions states match existing states.");
            return null;
        }
    }
}
