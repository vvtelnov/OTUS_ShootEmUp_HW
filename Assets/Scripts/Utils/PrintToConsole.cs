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
    }
}