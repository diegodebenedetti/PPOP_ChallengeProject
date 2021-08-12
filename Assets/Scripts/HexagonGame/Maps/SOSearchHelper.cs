using UnityEditor;
using UnityEngine;

public static class SOSearchHelper
{
    public static T[] GetAllInstances<T>() where T : ScriptableObject // Use Object instead of SO to support Monobihaviours
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);  
        
        T[] a = new T[guids.Length];
        
        for (int i = 0; i < guids.Length; i++)      
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
        }

        return a;

    }
}
