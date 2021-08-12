using UnityEngine;

namespace Tiles
{
    [CreateAssetMenu(menuName ="Tiles/New TileType")]
    public class TileType : ScriptableObject
    {   
        
        [SerializeField] private string _tileName; //Podria Ser un Enum cuando este todo mas definido.
        [SerializeField] private int _tileCost;
        [SerializeField] private Texture _sprite;

        public string TileName => _tileName;
        public int TileCost => _tileCost;

        public Texture Sprite => _sprite;

    }
}