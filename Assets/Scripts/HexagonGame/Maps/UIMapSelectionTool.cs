using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Map{
public class UIMapSelectionTool : MonoBehaviour, IPointerClickHandler
{
    public static event Action<SOMapFile> OnMapSelected = delegate{};
    private SOMapFile _mapFile;
    private TextMeshProUGUI _text;
    
    private void Awake() {

        _text = GetComponentInChildren<TextMeshProUGUI>();
    
    }

    public void SetMapText(string pText){

        _text.SetText(pText);
    }

    public void SetMapFile(SOMapFile pMapFile)
    {
        _mapFile = pMapFile;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnMapSelected.Invoke(_mapFile);
    }
}

}