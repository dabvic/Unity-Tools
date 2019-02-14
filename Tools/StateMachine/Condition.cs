using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tools.StateMachine
{
    /// <summary>
    /// Decisions are components that will be evaluated by transitions, every frame, and will return true or false. Examples include time spent in a state, distance to a target, or object detection within an area.  
    /// </summary>
    public abstract class Condition : MonoBehaviour
    {
        /// Performed every frame, transition's outcome is determined here.
        public abstract bool CheckCondition();

        public bool conditionEnabled;
        protected StateMachine stateMachine;

        /// <summary>
        /// On Start we initialize our Decision
        /// </summary>
        protected virtual void Start()
        {
            stateMachine = gameObject.GetComponent<StateMachine>();
            Initialization();
        }
        
        /// <summary>
        /// Provided if further Initialization is required 
        /// </summary>
        public virtual void Initialization()
        {

        }

        /// <summary>
        /// Triggered when the StateMachine enters a State this Condition is in
        /// </summary>
        public virtual void OnEnterState()
        {
            conditionEnabled = true;
        }

        /// <summary>
        ///  Triggered when the StateMachine exits a State this Condition is in
        /// </summary>
        public virtual void OnExitState()
        {
            conditionEnabled = false;
        }
    }
}
