using UnityEngine;

[CreateAssetMenu(menuName = "Mainmenu/ButtonConfigSettings")]
public class SOStartButtonConfig : ScriptableObject
{
    [Header("General Settings")]
    [Range(0.1f,0.5f)]
    [SerializeField] private float _movementDelay;

    [Range(30f,80f)]
    [SerializeField] private float _movementAmmount;

    [Header("Text for the Seccond Chance")]
    [SerializeField] private string _seccondChanceText;


    public float MovementDelay => _movementDelay;
    public float MovementAmmount => _movementAmmount;
    public string SeccondChanceText => _seccondChanceText;



}
