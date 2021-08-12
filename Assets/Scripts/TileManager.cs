using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;

namespace GameManagement{
public static class TileManager
{
    [SerializeField] public static List<UITile> UITilesOnGame = new List<UITile>();
    [SerializeField] public static List<Tile> TilesOnGame = new List<Tile>();
    private static int _gridHeight;
    private static int _gridWith;

    public static Tile GetTile(int x, int y){

        try
        {
            return TilesOnGame.First(tile => tile.CoordinateX == x && tile.CoordinateY == y);
        }
        catch (System.Exception)
        {
            
            throw new System.Exception($"Tile Out Of Bounds / Invalid Tile {x} || {y}");
        }
    }

    public static void BindGridSettings(int pGridHeight, int pGridWith){

        _gridHeight = pGridHeight;
        _gridWith = pGridWith;

    }
    
    public static List<Tile> GetNeighbours(int x, int y){

        List<Tile> neighboursList = new List<Tile>();

        if(x > 0)
            neighboursList.Add(GetTile(x-1, y));
        
        if(x < _gridWith - 1)
            neighboursList.Add(GetTile(x+1 , y));

        if(y % 2 == 0)
     {
         
         if( y > 0 && x > 0) neighboursList.Add(GetTile((x - 1), (y - 1)));
 
         
         if( y > 0 ) neighboursList.Add(GetTile(x, (y - 1)));
         
         
         if( y < _gridHeight -1 && x > 0 ) neighboursList.Add(GetTile((x - 1),  (y + 1)));
 
         
         if( y < _gridHeight -1 ) neighboursList.Add(GetTile(x, (y + 1)));

     }else {

         
         if( y > 0 ) neighboursList.Add(GetTile(x,  + (y - 1)));
 
         
         if( y > 0 && x < _gridWith -1) neighboursList.Add(GetTile((x + 1) , (y - 1)));
         
         
         if( y < _gridHeight - 1) neighboursList.Add(GetTile(x , (y + 1)));
 
        
         if( y < _gridHeight - 1 && x < _gridWith - 1) neighboursList.Add(GetTile((x + 1), (y + 1)));

     }
        
        return neighboursList;

        
    }

    public static List<UITile> ActiveUITilesOnGame(){
        
        return UITilesOnGame.Where(x => x.isActiveAndEnabled).ToList();
    }
    public static void DeactivateUITileGrid(){

        if(UITilesOnGame.Count <= 0) return;

        foreach (var UItile in UITilesOnGame)
        {
            UItile.gameObject.SetActive(false);
        }

    }
}

}

