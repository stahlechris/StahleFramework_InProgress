using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using MEC;
namespace Stahle.Utility
{
    public class PutParticlesBackInObjectPoolWhenTheyAreDonePlaying : MonoBehaviour
    {
        [SerializeField] ParticleSystem ps;

        IEnumerator Start()
        {
            //erase this line once you have made prefabs!
            ps = GetComponent<ParticleSystem>();

            yield return new WaitUntil(() => ps.isStopped);

            gameObject.SetActive(false);
        }
    }
}