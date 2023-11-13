using UnityEngine;
using System;

namespace Guymon.DesignPatterns
{
    public abstract class BaseState2D<T> where T : Enum
    {
        public BaseState2D(T key) {
            StateKey = key;
        }
        public T StateKey {get; private set;}
        public virtual void OnEnterState(StateMessenger2D<T> messenger) {}
        public virtual void OnExitState(StateMessenger2D<T> messenger) {}
        public virtual void UpdateState(StateMessenger2D<T> messenger) {}
        public virtual void OnTriggerEnter2D(Collider2D other, StateMessenger2D<T> messenger) {}
        public virtual void OnTriggerStay2D(Collider2D other, StateMessenger2D<T> messenger) {}
        public virtual void OnTriggerExit2D(Collider2D other, StateMessenger2D<T> messenger) {}
    }
}