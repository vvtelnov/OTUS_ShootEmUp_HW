using System.Collections.Generic;
using GameSystem.GameContext;
using UnityEngine;

namespace Utils
{
    public static class PrintToConsole
    {
        public static void Print(string message)
        {
#if UNITY_EDITOR
            Debug.Log(message);
#endif
        }
        
        public static void PrintAsError(string message)
        {
#if UNITY_EDITOR
            Debug.LogError(message);
#endif
        }
        
        public static void PrintGameOver()
        {
#if UNITY_EDITOR
            Debug.Log($"<color=#6B1D0C>------------------------</color>");
            Debug.Log($"<color=#E4340E>----> GAME OVER!!! <----</color>");
            Debug.Log($"<color=#6B1D0C>------------------------</color>");
#endif
        }
        
        public static void PrintYellow(string msg)
        {
#if UNITY_EDITOR
            Debug.Log($"<color=#E9E638>----> {msg} <----</color>");
#endif
        }
        
        public static void PrintGreen(string msg)
        {
#if UNITY_EDITOR
            Debug.Log($"<color=#3BE938>----> {msg} <----</color>");
#endif
        }
        
        public static void PrintWhite(string msg)
        {
#if UNITY_EDITOR
            Debug.Log($"<color=#DADBE2>----> {msg} <----</color>");
#endif
        }

        public static void Debug_PrintAllGameElements(
            List<IGameElement> gameElements,
            List<IUpdateElement> updateElements,
            List<IUpdateInPauseElement> updateInPauseElements,
            List<IFixedUpdateElement> fixedUpdateElements,
            List<ILateUpdateElement> lateUpdateElements
        )
        {
            PrintYellow(new string('=', 20));
            PrintYellow(new string('=', 20));
           
            foreach (var i in gameElements)
            {
                Debug.Log($"[DEBUG] GameElements: {i}");
            } 
            foreach (var i in updateElements)
            {
                Debug.Log($"[DEBUG] updateElements: {i}");
            } 
            foreach (var i in updateInPauseElements)
            {
                Debug.Log($"[DEBUG] UpdateInPauseElements: {i}");
            } 
            foreach (var i in fixedUpdateElements)
            {
                Debug.Log($"[DEBUG] FixedUpdateElements: {i}");
            } 
            foreach (var i in lateUpdateElements)
            {
                Debug.Log($"[DEBUG] LateUpdateElements: {i}");
            } 
            
            Debug.Log(new string('-', 20));
            Debug.Log($"[DEBUG] GameElements Count: {gameElements.Count}");
            Debug.Log($"[DEBUG] updateElements Count: {updateElements.Count}");
            Debug.Log($"[DEBUG] UpdateInPauseElements Count: {updateInPauseElements.Count}");
            Debug.Log($"[DEBUG] FixedUpdateElements Count: {fixedUpdateElements.Count}");
            Debug.Log($"[DEBUG] LateUpdateElements Count: {lateUpdateElements.Count}");
            Debug.Log(new string('-', 20));
            
            PrintYellow(new string('=', 20));
            PrintYellow(new string('=', 20));
        }
    }
}