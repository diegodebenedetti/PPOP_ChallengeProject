using UITools;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tiles{

public class UITile : MonoBehaviour, IPlaceable, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField] private TileType _uiTileType;

    public TileType UITileType => _uiTileType;

    private RawImage _img;

    private TileType _provisoryTileTypeSelection;
    private int _coordinatesX;
    private int _coordinatesY;

    public int CoordinatesX => _coordinatesX;
    public int CoordinatesY => _coordinatesY;

    private void Start() {

        _img = GetComponent<RawImage>();

        UITerrainTool.OnToolSelected += SetProvisoryTileSelection;

    }

    private void SetProvisoryTileSelection(TileType pTileType){

            _provisoryTileTypeSelection = pTileType;
    }

    public void OnPointerClick(PointerEventData eventData)
        {
            if(_provisoryTileTypeSelection == null) return;
            _uiTileType = _provisoryTileTypeSelection;
            _img.texture = _uiTileType.Sprite;
        }

   public void OnPointerEnter(PointerEventData eventData)
        {
            if(_provisoryTileTypeSelection == null) return;

            if(Input.GetKey(KeyCode.Mouse0)) //Los inputs deberian de manejarse en una clase solo para eso.
                 _uiTileType = _provisoryTileTypeSelection;
                _img.texture = _uiTileType.Sprite;
        }
    
    public void SetCoordinates(int x, int y){

        _coordinatesX = x;
        _coordinatesY = y;

    }
    private void OnDestroy() => UITerrainTool.OnToolSelected -= SetProvisoryTileSelection;

    public void SelfDestroy(){

           
    }
 
}

}


