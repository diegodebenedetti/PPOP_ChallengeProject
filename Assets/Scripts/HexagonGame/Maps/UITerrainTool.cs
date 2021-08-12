using System;
using Tiles;
using UnityEngine;

namespace UITools{
public class UITerrainTool : MonoBehaviour
{
    //Observer
    public static event Action<TileType> OnToolSelected = delegate{};
    
    [SerializeField] private TileType _tileType;

    public void NotifyToolSelection(){

        OnToolSelected.Invoke(_tileType);
    }  

}

}
