using Grid;
using UnityEngine;

namespace UITools{
public class UINewMapAction : MonoBehaviour
{
    private UIGridGenerator _gridGenerator;
    private void Start() {
        _gridGenerator = FindObjectOfType<UIGridGenerator>();
    }

    public void GenerateUIGrid(){

        _gridGenerator.StartGrid();
    }
}
}

