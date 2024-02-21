#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Guymon.Utilities {
    public static class Console
    {
        static Console() {

        Console.info = EditorPrefs.GetBool(Console.INFO_MENU_NAME, true);
        Console.error = EditorPrefs.GetBool(Console.ERROR_MENU_NAME, true);
        Console.warning = EditorPrefs.GetBool(Console.WARNING_MENU_NAME, true);
        Console.test = EditorPrefs.GetBool(Console.TEST_MENU_NAME, true);
        Menu.SetChecked(Console.INFO_MENU_NAME, info);
        Menu.SetChecked(Console.ERROR_MENU_NAME, error);
        Menu.SetChecked(Console.WARNING_MENU_NAME, warning);
        Menu.SetChecked(Console.TEST_MENU_NAME, test);
        
        }
        private const string INFO_MENU_NAME = "Tools/Console/Info";
        private const string ERROR_MENU_NAME = "Tools/Console/Error";
        private const string WARNING_MENU_NAME = "Tools/Console/Warning";
        private const string TEST_MENU_NAME = "Tools/Console/Test";
        [MenuItem(Console.INFO_MENU_NAME)]
        private static void ToggleActionI() {
            info = !info;
            Menu.SetChecked(Console.INFO_MENU_NAME, info);
            EditorPrefs.SetBool(Console.INFO_MENU_NAME, info);
        }
        [MenuItem(Console.ERROR_MENU_NAME)]
        private static void ToggleActionE() {
            error = !error;
            Menu.SetChecked(Console.ERROR_MENU_NAME, error);
            EditorPrefs.SetBool(Console.ERROR_MENU_NAME, error);
        }
        [MenuItem(Console.WARNING_MENU_NAME)]
        private static void ToggleActionW() {
            warning = !warning;
            Menu.SetChecked(Console.WARNING_MENU_NAME, warning);
            EditorPrefs.SetBool(Console.WARNING_MENU_NAME, warning);
        }
        [MenuItem(Console.TEST_MENU_NAME)]
        private static void ToggleActionT() {
            test = !test;
            Menu.SetChecked(Console.TEST_MENU_NAME, test);
            EditorPrefs.SetBool(Console.TEST_MENU_NAME, test);
        }
        private static bool info = true;
        private static bool error = true;
        private static bool warning = true;
        private static bool test = true;
        public static void Info(string message) {
            if(info) Debug.Log(message);
        }
        public static void Error(string message) {
            if(error) Debug.LogError(message);
        }
        public static void Warning(string message) {
            if(warning) Debug.LogWarning(message);
        }
        public static void Test(string message) {
            if(test) Debug.Log(message);
        }
    }
}
#endif
