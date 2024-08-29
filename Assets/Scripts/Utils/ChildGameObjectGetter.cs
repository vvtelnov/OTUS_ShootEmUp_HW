using System;
using UnityEngine;

namespace Utils
{
    public static class ChildGameObjectGetter
    {
        public static Transform GetChildTransform(GameObject parentObj, string childObjName)
        {
            foreach (Transform child in parentObj.transform)
            {
                if (child.name != childObjName)
                    continue;

                return child;
            }
            
            throw new Exception($"There is no object with name ${childObjName} is {parentObj}"); 
        }
        
        public static GameObject GetChildGameObject(GameObject parentObj, string childObjName)
        {
            foreach (Transform child in parentObj.transform)
            {
                if (child.name != childObjName)
                    continue;

                return child.gameObject;
            }
            
            throw new Exception($"There is no object with name ${childObjName} is {parentObj}"); 
        }
    }
}