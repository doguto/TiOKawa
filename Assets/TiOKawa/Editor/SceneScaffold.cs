using System.IO;
using UnityEditor;
using UnityEngine;

namespace TiOKawa.Editor
{
    public class SceneScaffold : EditorWindow
    {
        string sceneName = "";
        
        [MenuItem("Tools/SceneScaffold")]
        public static void ShowWindow()
        {
            var window = GetWindow<SceneScaffold>("SceneScaffold");
            window.minSize = new Vector2(500, 100);
        }

        void OnGUI()
        {
            GUILayout.Label("Scene Scaffold", EditorStyles.boldLabel);
            
            EditorGUILayout.BeginHorizontal();
            sceneName = EditorGUILayout.TextField("Directory Name", sceneName);
            GUILayout.Space(5);

            if (GUILayout.Button("Create Scripts folder"))
            {
                if (string.IsNullOrWhiteSpace(sceneName))
                {
                    EditorUtility.DisplayDialog("Error", "Please enter a Scene Name.", "OK");
                    return;
                }

                CreateAssemblyReferences();
                this.Close();
            }
            
            GUILayout.EndHorizontal();
        }
        
        void CreateAssemblyReferences()
        {
            const string scriptsBasePath = "Assets/TiOKawa/Scenes";
            string[] asmdefNames = { "Model", "Presenter", "View" };

            var scenePath = Path.Combine(scriptsBasePath, sceneName);
            var creatingScriptsPath = Path.Combine(scenePath, "Scripts");
            
            Directory.CreateDirectory(creatingScriptsPath);
            foreach (var asmdefName in asmdefNames)
            {
                var subFolderPath = Path.Combine(creatingScriptsPath, asmdefName);
                if (Directory.Exists(subFolderPath))
                {
                    Debug.LogWarning($"{asmdefName} Directory is already existed.");
                    continue;
                }
                Directory.CreateDirectory(subFolderPath);

                var asmrefPath = Path.Combine(subFolderPath, asmdefName + ".asmref");

                var asmrefContent = $@"{{
                    ""reference"": ""{asmdefName}""
                }}";

                File.WriteAllText(asmrefPath, asmrefContent);
                Debug.Log($"Created asmref: {asmrefPath}");
            }

            AssetDatabase.Refresh();
            EditorUtility.DisplayDialog("Done", $"Assembly References for '{sceneName}' Created!", "OK");
        }
    }
}
