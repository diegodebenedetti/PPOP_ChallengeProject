using UnityEngine;
using VFX;

namespace AnimationsAndFx{
public class TileAnimator : MonoBehaviour
{
   
   [SerializeField] Vector3 _vfxOffset;
  
   public void HoverInAnimation(float pAmmount, float pDelay){

       transform.LeanMoveLocalY(pAmmount, pDelay);

   }

    public void HoverOutAnimation(float pDelay){

       transform.LeanMoveLocalY(0, pDelay);
       
   }

   public void PlayTileSelectionEffect(){
       
       VFXPlayer.Instance.PlayEffectByName("Selection",transform.position + _vfxOffset);

   }

   public void PlayTilePathEffect(){
       

   }
}
}
