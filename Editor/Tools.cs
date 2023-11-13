using UnityEditor;
using System.IO;
using UnityEngine;

namespace Guymon.Utilities
{
    public static class Tools
    {
        public static string rootProject = "_Project";
        [MenuItem("Tools/Setup/Create Folders")]
        public static void CreateDefaultFolders() {
            Directory.CreateDirectory(Path.Combine(Application.dataPath, rootProject));
            Dir(rootProject, "Resources", "Objects", "Scripts", "Sounds", "Sprites", "Scenes");
            AssetDatabase.Refresh();
        }
        public static void Dir(string root, params string[] dir) {
            string fullPath = Path.Combine(Application.dataPath, root);
            foreach (string newDir in dir) {
                Directory.CreateDirectory(Path.Combine(fullPath, newDir));
            }
        }
    }
}
