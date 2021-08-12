using System;
using GameManagement;
using Tiles;
using UnityEngine;


namespace Grid{
public abstract class GridBase : MonoBehaviour
{
    [Header("Grid Settings")]
    [SerializeField] private Vector3 _startingPos;
    
    [Range(3,8)]
    [SerializeField] private int _gridWith =8, _gridHeight = 8;
    [SerializeField] private float _gap;
    
    private bool _IsfirstTimeLoading = true;
    private TileFactory _tileFactory;
    private float _tileWith = 1;
    private float _tileHeight = 1;

    internal int GridWith => _gridWith;
    internal int GridHeight => _gridHeight;
    internal float TileWith => _tileWith;
    internal float TileHeight => _tileHeight;
    internal Vector3 StartingPos => _startingPos;
    internal TileFactory TileFactory => _tileFactory;
    
    private void Start() {
        
        try
        {
            _tileFactory = FindObjectOfType<TileFactory>();
            
        }
        catch (System.Exception)
        {
            
            throw new Exception("Coudnt Find Tile Factory Object on the Project");
        }
        TileManager.BindGridSettings(_gridHeight,_gridHeight);
    }

    internal virtual  void CreateGrid()
    {

       GameObject emptyContainer = CreateParent();
       
        
            for (int y = 0; y < _gridHeight; y++)
            {
                for (int x = 0; x < _gridWith; x++)
                {
                    IPlaceable tile = InstantiateTile(x , y);
                    MoveTileToPositionAndRenameIt(tile, x, y);
                    ReParentTile(tile, emptyContainer);
                    

                }
            }

    }
    internal virtual void AddGap()
        {
            if(_IsfirstTimeLoading){

            _tileWith += _tileWith * _gap;
            _tileHeight += _tileHeight * _gap;
            _IsfirstTimeLoading = false;

            }
            
        }
    internal void SetStartingPos(Vector3 pPos){
        
        _startingPos = pPos;
    }
    
    public virtual Vector3 CalculateWorldPosition(Vector2 pGridPos)
        {
            float offset = 0;

            if (pGridPos.y % 2 != 0){

                    offset = _tileWith / 2;
            }
            
 
            float x = StartingPos.x + pGridPos.x * _tileWith + offset;
            float z = StartingPos.z - pGridPos.y * _tileHeight * 0.75f;

            
            return new Vector3(x, 0, z);
    }

    public abstract GameObject CreateParent();
    public abstract void ReParentTile(IPlaceable tile, GameObject emptyContainer);
    public abstract void MoveTileToPositionAndRenameIt(IPlaceable tile, int x, int y);
    public abstract IPlaceable InstantiateTile(int x, int y);


}

}
