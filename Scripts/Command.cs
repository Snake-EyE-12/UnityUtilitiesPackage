using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guymon.DesignPatterns {
    /// <summary>
    /// <para>Abstract Class For Interchangeable Executable Methods</para>
    /// Note: Child Class Name Should Demonstrate Functionality
    /// </summary>
    public interface Command
    {
        /// <summary>
        /// Executes Functionality
        /// </summary>
        public abstract void Execute();
        /// <summary>
        /// Reversive Implementation of Execute
        /// </summary>
        public abstract void Undo();

    }
}