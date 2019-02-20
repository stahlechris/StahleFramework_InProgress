using UnityEngine;
using Stahle.Utility;

namespace Stahle.PowerUpSystem
{
    public abstract class PowerUp_Behavior : MonoBehaviour
    {
        protected PowerUp_Config config;
        public abstract void Use(GameObject target);

        public void SetConfig(PowerUp_Config config)
        {
            this.config = config;
        }
        protected void PlayApplyParticleFX()
        {
            //Get the particle and clone it
            GameObject particlePrefab = config.GetApplyPowerParticlePrefab();
            //#IF NO OBJECT POOL var prefabClone = Instantiate(particlePrefab, transform.position, particlePrefab.transform.rotation);
            GameObject prefabPoolClone = ObjectPooler.SharedInstance.GetPooledObject(config.GetApplyPowerPrefabEnumName());
            //#IF NO OBJECT POOL prefabClone.transform.parent = transform;
            //#IF NO OBJECT POOL prefabClone.GetComponentInChildren<ParticleSystem>().Play();
        }

        protected void PlayCastParticleFX()
        {

        }

        protected void PlayApplyPowerAudioClip()
        {

        }
        protected void PlayerCastPowerAudioClip()
        {
            AudioClip specialAbilitySound = config.GetCastAudioClip();
            //SFX_Player.Instance.PlaySFX(specialAbilitySound, 1, 1, true);
            //var audioSource = GetComponent<AudioSource>();
            //audioSource.PlayOneShot(specialAbilitySound);
        }
    }
}