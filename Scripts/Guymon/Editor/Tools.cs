#if UNITY_EDITOR
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
            Dir(rootProject, "Resources", "Prefabs", "Scripts", "Sounds", "Textures", "Scenes", "Animations", "Externals");
            Directory.CreateDirectory(Path.Combine(Application.dataPath, rootProject + "/Externals/Color Palette.asset"));
            File.WriteAllText(Path.Combine(Application.dataPath, rootProject + "/Externals/Color Palette.asset"), """
            %YAML 1.1
%TAG !u! tag:unity3d.com,2011:
--- !u!114 &11400000
MonoBehaviour:
  m_ObjectHideFlags: 0
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: 0}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 11500000, guid: 7edb8eb7125ea44f68bbe616b44fa9bc, type: 3}
  m_Name: Color Palette
  m_EditorClassIdentifier: 
  colorDesigns:
  - keyChar: //
    textColor: {r: 1, g: 1, b: 1, a: 1}
    backgroundColor: {r: 0, g: 0.10323961, b: 0.10323961, a: 1}
    textAlignment: 4
    fontStyle: 3
  - keyChar: ///
    textColor: {r: 1, g: 1, b: 1, a: 1}
    backgroundColor: {r: 0, g: 0.6152477, b: 1, a: 1}
    textAlignment: 5
    fontStyle: 1
  - keyChar: '#'
    textColor: {r: 1, g: 1, b: 1, a: 1}
    backgroundColor: {r: 0.5058824, g: 0.84705883, b: 0.81960785, a: 1}
    textAlignment: 3
    fontStyle: 1
  - keyChar: '@'
    textColor: {r: 1, g: 1, b: 1, a: 1}
    backgroundColor: {r: 0.8207547, g: 0.6350863, b: 0, a: 1}
    textAlignment: 4
    fontStyle: 1
  - keyChar: $
    textColor: {r: 1, g: 1, b: 1, a: 1}
    backgroundColor: {r: 0.5903926, g: 0.12967247, b: 0.8867924, a: 1}
    textAlignment: 4
    fontStyle: 0
            """)

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
#endif
