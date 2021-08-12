using System.Collections.Generic;
using PathFinding;
using UnityEngine.EventSystems;
using UnityEngine;
using AnimationsAndFx;
using System;
using GameManagement;

namespace Tiles{
    public class Tile : MonoBehaviour, IAStarNode, IPlaceable, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public static event Action<Tile> OnSelected = delegate{};
        [SerializeField] private TileType _tileType;
        [SerializeField] private bool _isSelectable = true;

        private bool _isSelected; 
        private int _coordinateX;
        private int _coordinateY;
       
        private TileAnimator _tileAnim;

        public TileType TileType => _tileType;
        public TileAnimator TileAnimator => _tileAnim;

        
        public int CoordinateX => _coordinateX;
        public int CoordinateY => _coordinateY;
        public bool IsSelectable => _isSelectable;
 
        private void Start() {

            try
            {
                _tileAnim = GetComponent<TileAnimator>();
            }
            catch (System.Exception)
            {
                
                throw new System.Exception("No Tile Animator Assigned");
            }
            
        }

        public IEnumerable<IAStarNode> Neighbours
        {
            get
            {
                return TileManager.GetNeighbours(_coordinateX,_coordinateY);
            }
        }    

        public float CostTo(IAStarNode neighbour)
        {
            if(neighbour == null)
                Debug.Log($"{CoordinateX} || {CoordinateY}");

            Tile neighbourTile = (Tile)neighbour;
            return neighbourTile.TileType.TileCost;
        }

        public float EstimatedCostTo(IAStarNode target)
        {
            Tile targetTile = (Tile)target;
            return Mathf.Abs(_coordinateX - targetTile.CoordinateX) + Mathf.Abs(_coordinateY - targetTile.CoordinateY);

        }

        public void SetCoordinates(int x, int y){

            _coordinateX = x;
            _coordinateY = y;

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(!_isSelectable) return;

            _tileAnim.HoverInAnimation(0.15f, 0.2f);
        
        }

        public void OnPointerExit(PointerEventData eventData)
        {
             if(!_isSelectable) return;

            _tileAnim.HoverOutAnimation(0.3f);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(!_isSelectable) return;

            _isSelected = !_isSelected;
            
            if(_isSelected){

                OnSelected.Invoke(this);
                _tileAnim.PlayTileSelectionEffect();
            
            } 
        }
    
        public void SelfDestroy(){

            Destroy(this.gameObject);
        }
    
        public void ToggleHoverLocked(){
            
            _isSelectable = !_isSelectable;
        }

    }

}