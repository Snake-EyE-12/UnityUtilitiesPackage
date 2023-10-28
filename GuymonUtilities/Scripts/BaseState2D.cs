using UnityEngine;
using System;

namespace Guymon.DesignPatterns
{
    public abstract class BaseState2D<EState> where EState : Enum
    {
        public BaseState2D(EState key) {
            StateKey = key;
        }
        public EState StateKey {get; private set;}
        public abstract void OnEnterState();
        public abstract void OnExitState();
        public abstract void UpdateState();
        public abstract EState GetNextState();
        public abstract void OnTriggerEnter2D(Collider other);
        public abstract void OnTriggerStay2D(Collider other);
        public abstract void OnTriggerExit2D(Collider other);
    }
}