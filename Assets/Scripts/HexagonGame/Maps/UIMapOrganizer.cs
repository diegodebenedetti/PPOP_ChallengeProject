using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Map{
public class UIMapOrganizer : MonoBehaviour
{
    [SerializeField] private UIMapSelectionTool _mapSelectionToolPrefab;

    private List<SOMapFile> _maps = new List<SOMapFile>();

    int _index;
  
    private void Start() {
        
        ArrangeMapButtons();
        MapSOFileGenerator.OnMapAdded += AddEntryToList;
        
        _index = 0;
    }
    private void ArrangeMapButtons() {

        _maps = SOSearchHelper.GetAllInstances<SOMapFile>().ToList();
        
        if(_maps.Count <= 0 ) return;

        
        foreach (var map in _maps)
        {               
           AddEntryToList(map);
            
            _index++;
        }
    }

    public void AddEntryToList(SOMapFile pMapFile){

        UIMapSelectionTool mapSelectionTool = Instantiate(_mapSelectionToolPrefab);
        mapSelectionTool.transform.SetParent(transform,false);
        mapSelectionTool.name = $"MapTool_{_index}_btn";
        mapSelectionTool.SetMapText(pMapFile.MapName);
        mapSelectionTool.SetMapFile(pMapFile);
                

    }

   
}

}
