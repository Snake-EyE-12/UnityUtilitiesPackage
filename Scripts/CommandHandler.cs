using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Guymon.Utilities;

namespace Guymon.DesignPatterns {
    /// <summary>
    /// Holds a List of Commands for Execution, Undo, and Redo
    /// </summary>
    public class CommandHandler : MonoBehaviour
    {
        private static List<Command> commands = new List<Command>();
        private static int index = 0;
        /// <summary>
        /// Executes a Command and Erases Previously Undone Commands
        /// </summary>
        /// <param name="command">Command to be Executed</param>
        public static void Execute(Command command) {
            if(commands.Count > index) commands.RemoveRange(index, commands.Count - 1);
            commands.Add(command);
            command.execute();
            index++;
        }
        /// <summary>
        /// Undoes Previously Executed Command
        /// </summary>
        public static void Undo() {
            if(index <= 0) {
                #if UNITY_EDITOR
                Guymon.Utilities.Console.Warning("CommandHandler: No command to undo");
                #endif
                return;
            }
            index--;
            commands[index].undo();
        }
        /// <summary>
        /// Re-Executes a Previously Undone Command
        /// </summary>
        public static void Redo() {
            if(index == commands.Count) {
                #if UNITY_EDITOR
                Guymon.Utilities.Console.Warning("CommandHandler: No command to redo");
                #endif
                return;
            }
            commands[index].execute();
            index++;
        }
    }
}