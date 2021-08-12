using System;
using System.Collections.Generic;
using System.Text;
using Tiles;
using UnityEngine;


namespace Map{
[CreateAssetMenu(menuName = "Maps/Map File")]
public class SOMapFile : ScriptableObject
{
    [SerializeField] private string _mapName;
    public string MapName => _mapName;

    [SerializeField] private string _mapCode;
    private StringBuilder _stringBuilder = new StringBuilder();

    public string MapCode => _mapCode;



    public void Bind(string pMapName,List<UITile> pPlaceables){
        
        _mapName = pMapName;

            foreach (var placeable in pPlaceables)
        {
            _stringBuilder.Append($"{placeable.CoordinatesX},{placeable.CoordinatesY},{placeable.UITileType.TileName}|");
        }

        _mapCode = _stringBuilder.ToString();
        
        
    }

    public string GetTileNameByPosition(int x, int y){

            string[] split = _mapCode.Split(new []{'|'}, StringSplitOptions.RemoveEmptyEntries);
            
            string name = null;

            foreach (var item in split)
            {

                var itemSplitted = item.Split(',');

                var xPosition = int.Parse(itemSplitted[0]);
                var yPosition = int.Parse(itemSplitted[1]);
                var tileName = itemSplitted[2];

                
                if(xPosition == x && yPosition == y){
                    
                    name = tileName;
                    break;
                }

            }

            return name;
    }


}

}
