using UnityEngine;
using System.Collections.Generic;
using MEC;

namespace Stahle.Misc
{
    public class DamageZone : MonoBehaviour
    {
        [Header("The audiosource I play damage sounds from every time I damage something.")]
        [SerializeField] AudioSource m_AudioSource;

        [Header("The Audio Clips I play every time I damage something.")]
        [SerializeField] AudioClip[] gettingHitAudioClip;

        [SerializeField] int damageAmount = 10;
        [Header("Every this seconds I apply damage.")]
        [SerializeField] float damageRepeatRate = 2f;

        [Header("Do I apply damage every X seconds?")]
        [SerializeField] bool isDamageAppliedRepeatedly = true;

        private bool _isCausingDamage = false;
        private HealthSystem _healthSystem;
        private Transform thingImDamaging;

        private void Start()
        {
            if(damageRepeatRate < 0.1)
            {
                isDamageAppliedRepeatedly = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var healthSystem = GetComponentInChildren<HealthSystem>();

            if (healthSystem != null)
            {
                thingImDamaging = other.transform;
                _healthSystem = healthSystem;

                _isCausingDamage = true;

                if (isDamageAppliedRepeatedly)
                {
                    Timing.RunCoroutine(DealDamageRepeatedly(damageRepeatRate));
                }
                else
                {
                    //healthSystem.TakeDamage(damageAmount);
                    _isCausingDamage = false;
                }
            }
        }

        IEnumerator<float> DealDamageRepeatedly(float repeatRate)
        {
            while (_isCausingDamage)
            {
                //_healthSystem.TakeDamage(damageAmount);
                yield return Timing.WaitForSeconds(repeatRate);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform == thingImDamaging)
            {
                _isCausingDamage = false;
                Timing.KillCoroutines();
            }
        }
    }
}