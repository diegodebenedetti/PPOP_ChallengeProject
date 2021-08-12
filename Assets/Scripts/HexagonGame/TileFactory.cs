using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Tiles{
public class TileFactory : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private List<Tile> _tilePrefabs;
    [SerializeField] private List<UITile> _uiTilePrefabs;

  
    public Tile GetRandomTile(){

        int randomTile = Random.Range(0, _tilePrefabs.Count);
        return Instantiate(_tilePrefabs[randomTile]);
    }

    public Tile GetTileByType(string ptype){
        
        return Instantiate(_tilePrefabs.FirstOrDefault(x => x.TileType.TileName.Equals(ptype)));

    }

    public UITile GetUITileByType(string ptype){

        return Instantiate(_uiTilePrefabs.FirstOrDefault(x => x.UITileType.TileName.Equals(ptype)));

    }

 }

}
