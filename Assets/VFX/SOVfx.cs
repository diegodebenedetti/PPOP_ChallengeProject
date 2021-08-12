using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VFX{
[CreateAssetMenu(menuName = "VFX/New Effect")]
public class SOVfx : ScriptableObject
{

    [SerializeField] private string _vfxName;
    [SerializeField] private ParticleSystem _particlePrefab;

    public string VFXName => _vfxName;
    public ParticleSystem GetParticleVFX(){

       return Instantiate(_particlePrefab);

    }

}
}
