using GameManagement;
using Tiles;
using UnityEngine;

namespace Grid{
public class UIGridGenerator : GridBase
{

    [Header("Grid Settings")]
    [SerializeField] private RectTransform _parent;
        
    public void StartGrid()
        {
            AddGap();
            CreateGrid();
        }
    
    public override void MoveTileToPositionAndRenameIt(IPlaceable pTile, int x, int y)
    {
        UITile tile = (UITile)pTile;

        RectTransform tileTransform = tile.GetComponent<RectTransform>();

            Vector2 gridPos = new Vector2(x, y);
            tile.SetCoordinates(x, y);
            tileTransform.anchoredPosition = CalculateWorldPosition(gridPos);
            tile.name = $"Tile {x} | {y}";
            TileManager.UITilesOnGame.Add(tile);

    }

    public override void ReParentTile(IPlaceable pTile, GameObject pParent)
    {
        UITile tile = (UITile)pTile;

        tile.transform.SetParent(pParent.transform,false);
        
    }
    
    public override Vector3 CalculateWorldPosition(Vector2 pGridPos)
        {
            float offset = 0;

            if (pGridPos.y % 2 != 0){

                    offset = TileWith / 2;
            }
            
 
            float x = StartingPos.x + pGridPos.x * TileWith + offset;
            float y = StartingPos.z - pGridPos.y * TileHeight * 0.75f;

            
            return new Vector3(x, y ,0);
        }

    public override GameObject CreateParent()
    {
        GameObject emptyContainer = Instantiate(new GameObject("MapContainer"));
        emptyContainer.AddComponent<CanvasRenderer>();
        emptyContainer.AddComponent<RectTransform>();
        
        emptyContainer.transform.SetParent(_parent);

        RectTransform emptyContainerRect = emptyContainer.GetComponent<RectTransform>();


        emptyContainerRect.anchorMin = new Vector2(0.1f,0.9f);
        emptyContainerRect.anchorMax = new Vector2(0.1f,0.9f);
        emptyContainerRect.anchoredPosition = Vector3.zero;

        emptyContainer.transform.localScale = new Vector3(40,40,0);
        

        return emptyContainer;
    }

    public override IPlaceable InstantiateTile(int x, int y)
    {
        return TileFactory.GetUITileByType("UIBlank");
    }
  

    }

}
