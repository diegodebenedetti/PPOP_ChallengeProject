using System;
using System.Collections.Generic;
using GameManagement;
using Tiles;
using UnityEditor;
using UnityEngine;

namespace Map{
public class MapSOFileGenerator : MonoBehaviour
{
    public static event Action<SOMapFile> OnMapAdded = delegate{};
   
    public void GenerateSaveFileFromCurrentMap(string pName, List<UITile> pPlaceables){

        string id = DateTime.Now.ToString();
        string parseId = id.Replace('/','_').Replace(':','_');
                
        SOMapFile _mapFile = ScriptableObject.CreateInstance<SOMapFile>();
        
        AssetDatabase.CreateAsset(_mapFile, $"Assets/Scripts/HexagonGame/Maps/SavedMaps/Map_{pName}_{parseId}.asset");
        _mapFile.Bind($"{pName}_{parseId}",pPlaceables);       

        EditorUtility.SetDirty(_mapFile);
        AssetDatabase.SaveAssets();
        OnMapAdded.Invoke(_mapFile);

    }

}

}
