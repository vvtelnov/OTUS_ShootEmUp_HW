using GameSystem.GameContext;
using UnityEditor;
using UnityEngine;

namespace GameSystem.Editor
{
    [CustomEditor(typeof(GameLauncher))]
    public class GameLauncherEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawDefaultInspector();
            EditorGUILayout.Space ();
            EditorGUILayout.Space ();


            GameLauncher gameLauncher = (GameLauncher)target;
            
            if (GUILayout.Button("Launch Game with timer"))
            {
                gameLauncher.LaunchGameWithTimer();
            }            
        }
    }
}