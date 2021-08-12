using System.Collections.Generic;
using PathFinding;
using Tiles;
using UnityEngine;


namespace GameManagement{
public class GameManager : MonoBehaviour
{
    
    [SerializeField] private IAStarNode _originTile;
    [SerializeField] private IAStarNode _destinationTile;

    private void Start() {
        
        Tile.OnSelected += CheckSelection;
        
    }


    private void CheckSelection(IAStarNode pSelection) {
        
        if(_originTile == null)
            _originTile = pSelection;

        else if(_destinationTile == null){

            _destinationTile = pSelection;
            ShowPath();
            _originTile = null;
            _destinationTile = null;
            
        }
            
        else _originTile = pSelection;
     
    } 

    private void ShowPath(){

        IList<IAStarNode> pathList = new List<IAStarNode>();

        pathList = AStar.GetPath(_originTile, _destinationTile);

        if(pathList != null)
            {
                AnimatePath(pathList);

            }

        }

        private void AnimatePath(IList<IAStarNode> pathList)
        {
            for (int i = 0; i < pathList.Count; i++)
            {
                Tile tile = (Tile)pathList[i];
                tile.TileAnimator.HoverInAnimation(0.15f, 0.1f * i);
                tile.ToggleHoverLocked();
            }
        }

    }

}
