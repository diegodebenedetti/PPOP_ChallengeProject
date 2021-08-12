using System;
using System.Linq;
using GameManagement;
using Map;
using Tiles;
using UnityEngine;

namespace Grid{
public class GridGenerator : GridBase
{
        [SerializeField] private Transform _parent;
        private SOMapFile _mapFile;

        private TileFactory _tileF;

        private void Start() {

            _tileF = FindObjectOfType<TileFactory>();
            UIMapSelectionTool.OnMapSelected += BeginMapCreation;
        }

        private void BeginMapCreation(SOMapFile pMapFile)
        {
            if(pMapFile != null){

                _mapFile = pMapFile;
                StartGrid();
            }
    
        }

        [ContextMenu("Start Grid")]
        public void StartGrid()
        {
            AddGap();
            CalculatePosition();
            CreateGrid();
           
        }

        private void CalculatePosition()
        {

        float offset = 0;
        if (GridHeight / 2 % 2 != 0)
            offset = TileWith / 2;
 
        float x = -TileWith * (GridWith / 2) - offset;
        float z = TileHeight * 0.75f * (GridHeight / 2);
 
        SetStartingPos(new Vector3(x, 0, z));

        }

        public override GameObject CreateParent()
        {
             GameObject emptyContainer = Instantiate(new GameObject("3DMapContainer"));
             emptyContainer.transform.SetParent(_parent);
            
            return emptyContainer;
        }

        public override void ReParentTile(IPlaceable pTile, GameObject emptyContainer)
        {
            Tile tile = (Tile)pTile;

            tile.transform.parent = this.transform;
        }

        public override void MoveTileToPositionAndRenameIt(IPlaceable pTile, int x, int y)
        {
            Tile tile = (Tile)pTile;
           
            Vector2 gridPos = new Vector2(x, y);
            tile.SetCoordinates(x,y);

            tile.transform.position = new Vector3(0,30,0);
            tile.transform.LeanMove(CalculateWorldPosition(gridPos), 0.3f).setEaseOutCirc().setDelay(.25f * (x + y));
            tile.name = $"Tile {x} | {y}";
            TileManager.TilesOnGame.Add(tile);
        }

        public override IPlaceable InstantiateTile(int x, int y)
        {
           
            return  _tileF.GetTileByType(_mapFile.GetTileNameByPosition(x,y));
        }




    }
} 
