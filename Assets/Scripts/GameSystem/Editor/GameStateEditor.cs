using UnityEditor;
using UnityEngine;

namespace GameSystem.Editor
{
    [CustomEditor(typeof(GameContext))]
    public class GameStateEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawDefaultInspector();
            EditorGUILayout.Space ();
            EditorGUILayout.Space ();


            GameContext gameContext = (GameContext)target;
            
            if (GUILayout.Button("Initialize game"))
            {
                gameContext.InitializeGame();
            }            
            
            if (GUILayout.Button("Ready game"))
            {
                gameContext.ReadyGame();
            }            
            
            if (GUILayout.Button("Start game"))
            {
                gameContext.StartGame();
            }            
            
            EditorGUILayout.Space ();
            if (GUILayout.Button("Pause game"))
            {
                gameContext.PauseGame();
            }            
            
            if (GUILayout.Button("Resume game"))
            {
                gameContext.ResumeGame();
            }            

            EditorGUILayout.Space ();
            if (GUILayout.Button("Finish game"))
            {
                gameContext.FinishGame();
            }            
        }
    }
}