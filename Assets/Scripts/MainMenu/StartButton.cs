using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

namespace MainMenuCodes {
public class StartButton : MonoBehaviour, IPointerEnterHandler
{

    [SerializeField] private SOStartButtonConfig _buttonConfig;
    private Transform _myTransfrom;
    private TextMeshProUGUI _buttonText;
    private bool _isStarted;

          
    private void Awake() {

        _myTransfrom = this.transform;
        _buttonText = GetComponentInChildren<TextMeshProUGUI>();
    
    }

      public void OnPointerEnter(PointerEventData eventData)
    {

            if(_isStarted) return;

            MoveToAnotherPosition();
            ChangeText();
            
            _isStarted = true;

    }

    private void MoveToAnotherPosition(){

        if(!_buttonConfig) return;

        _myTransfrom.LeanMoveLocalY
        (-_buttonConfig.MovementAmmount , _buttonConfig.MovementDelay
        ).setEaseOutBounce();
    }

    private void ChangeText(){

        _buttonText.SetText(_buttonConfig.SeccondChanceText);
    }

}

}
