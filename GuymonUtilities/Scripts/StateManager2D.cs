using System.Collections.Generic;
using UnityEngine;
using System;
namespace Guymon.DesignPatterns
{
    public abstract class StateManager2D<EState> : MonoBehaviour where EState : Enum
    {
        protected Dictionary<EState, BaseState2D<EState>> States = new Dictionary<EState, BaseState2D<EState>>();
        protected BaseState2D<EState> CurrentState;
        protected bool IsTransitioningState = false;
        void Start() {
            CurrentState.OnEnterState();
        }
        void Update() {
            EState nextStateKey = CurrentState.GetNextState();
            if(!IsTransitioningState && nextStateKey.Equals(CurrentState.StateKey)) {
                CurrentState.UpdateState();
            }
            else if(!IsTransitioningState) {
                TransitionToState(nextStateKey);
            }
        }
        public void TransitionToState(EState stateKey) {
            IsTransitioningState = true;
            CurrentState.OnExitState();
            CurrentState = States[stateKey];
            CurrentState.OnEnterState();
            IsTransitioningState = false;
        }
        void OnTriggerEnter2D(Collider other) {
            CurrentState.OnTriggerEnter2D(other);
        }
        void OnTriggerStay2D(Collider other) {
            CurrentState.OnTriggerStay2D(other);
        }
        void OnTriggerExit2D(Collider other) {
            CurrentState.OnTriggerExit2D(other);
        }
    }
}