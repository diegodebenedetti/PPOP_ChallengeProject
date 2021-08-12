using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace VFX{
public class VFXPlayer : MonoBehaviour
{
    public static VFXPlayer Instance;

    //Singleton..
    void Awake(){

        if (Instance == null){

            Instance = this;
            DontDestroyOnLoad(this.gameObject);
    
        } else {
            Destroy(this);
        }
    }
    [SerializeField] private List<SOVfx> _effects;

    public void PlayEffectByName(string pName, Vector3 pPosition){

        ParticleSystem fx = _effects.FirstOrDefault(x => x.VFXName.Equals(pName)).GetParticleVFX();
        fx.transform.position = pPosition;
        fx.Play();

    }

}
}