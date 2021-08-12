using System.Collections.Generic;
using System.Linq;
using GameManagement;
using Map;
using Tiles;
using UnityEngine;
using UnityEngine.UI;


namespace UITools{
public class UISaveTool : MonoBehaviour
{

    private List<UITile> _uiTiles = new List<UITile>();
    private Button _myButton;

    private void Start() {

        _myButton = GetComponent<Button>();
    }

    private void Update() {

        _myButton.interactable = !IsMapUncompleted();
        
    }
    public void SaveMap(){

       
        if(IsMapUncompleted()){

            Debug.Log("Please Finish Up The Map");
            
        }else{
            
            //Maps are saved : Assets/Scripts/HexagonGame/Maps/SavedMaps/Map.asset
            //You could use a TextInputField on the UI to set the MAP custom NAME
            if(_uiTiles.Count >0){

                FindObjectOfType<MapSOFileGenerator>().GenerateSaveFileFromCurrentMap("Custom",_uiTiles);
                TileManager.DeactivateUITileGrid();
            }
            
        }
            
    }

    public bool IsMapUncompleted(){

         _uiTiles = TileManager.ActiveUITilesOnGame();
        return _uiTiles.FirstOrDefault(x => x.UITileType.TileName.Equals("UIBlank"));
    }
    
}

}
