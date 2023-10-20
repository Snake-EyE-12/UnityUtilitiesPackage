using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Guymon.Utilities {
    public static class Logger
    {
        static Logger() {

        Logger.info = EditorPrefs.GetBool(Logger.INFO_MENU_NAME, true);
        Logger.error = EditorPrefs.GetBool(Logger.ERROR_MENU_NAME, true);
        Logger.warning = EditorPrefs.GetBool(Logger.WARNING_MENU_NAME, true);
        
        }
        private const string INFO_MENU_NAME = "Tools/Logger/Info";
        private const string ERROR_MENU_NAME = "Tools/Logger/Error";
        private const string WARNING_MENU_NAME = "Tools/Logger/Warning";
        [MenuItem(Logger.INFO_MENU_NAME)]
        private static void ToggleActionI() {
            info = !info;
            Menu.SetChecked(Logger.INFO_MENU_NAME, info);
            EditorPrefs.SetBool(Logger.INFO_MENU_NAME, info);
        }
        [MenuItem(Logger.ERROR_MENU_NAME)]
        private static void ToggleActionE() {
            error = !error;
            Menu.SetChecked(Logger.ERROR_MENU_NAME, error);
            EditorPrefs.SetBool(Logger.ERROR_MENU_NAME, error);
        }
        [MenuItem(Logger.WARNING_MENU_NAME)]
        private static void ToggleActionW() {
            warning = !warning;
            Menu.SetChecked(Logger.WARNING_MENU_NAME, warning);
            EditorPrefs.SetBool(Logger.WARNING_MENU_NAME, warning);
        }
        private static bool info = true;
        private static bool error = true;
        private static bool warning = true;
        public static void Info(string message) {
            if(info) Debug.Log(message);
        }
        public static void Error(string message) {
            if(error) Debug.LogError(message);
        }
        public static void Warning(string message) {
            if(warning) Debug.LogWarning(message);
        }
    }
}