using Map;
using UnityEngine;

namespace MainCanvas{
public class UIMainCanvas : MonoBehaviour
{
    
    void Start()
    {
        UIMapSelectionTool.OnMapSelected +=CloseMainCanvas;
    }

    public void CloseMainCanvas(SOMapFile pMapfile){

        this.gameObject.SetActive(false);
    }


}
}
