//using System.Collections.Generic;
using System.Collections;
using UnityEngine;
//using MEC; //3rd Party Software MoreEffectiveCoroutines!
namespace Stahle.Utility
{
    public class DestroyParticlesWhenTheyAreFinishedPlaying : MonoBehaviour
    {
        //Please prefab whatever this is on to eliminate the GetComponent call!
        [SerializeField] ParticleSystem ps;

        IEnumerator Start()
        {
            //erase this line once you have made prefabs!
            ps = GetComponent<ParticleSystem>();

            yield return new WaitUntil(() => !ps.isEmitting);

            Destroy(gameObject);
        }
    }
}