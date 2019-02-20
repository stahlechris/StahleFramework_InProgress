using UnityEngine;

namespace Stahle.PowerUpSystem
{
    public abstract class PowerUp_Config : ScriptableObject
    {
        [Header("PowerUp General")]

        [SerializeField] int _manaCost = 0;

        [SerializeField] GameObject _applyPowerParticleFX;
        [SerializeField] GameObject _castPowerParticleFX;

        [SerializeField] AudioClip _applyAudioClip;
        [SerializeField] AudioClip _castAudioClip;

        protected PowerUp_Behavior behavior;
        protected PooledPrefabName _applyPowerPrefabEnumName;
        protected PooledPrefabName _castPowerPrefabEnumName;

        //PowerUp_Config's must return their matching behavior.cs on the objectToAttachTo
        public abstract PowerUp_Behavior GetBehaviorComponent(GameObject objectToAttachTo);

        //The controller of the PowerUp system, PowerUps.cs will call this and send itself as the gameObjectToAttachTo
        public void AttachSpecialAbilityTo(GameObject gameObjectToAttachTo)
        {
            PowerUp_Behavior behaviorComponent = GetBehaviorComponent(gameObjectToAttachTo);

            behaviorComponent.SetConfig(this);

            behavior = behaviorComponent;
        }

        public void Use(GameObject target)
        {
            behavior.Use(target);
        }
        //todo refactor to c#

        public int GetManaCost()
        {
            return _manaCost;
        }

        public AudioClip GetApplyAudioClip()
        {
            return _applyAudioClip;
        }

        public AudioClip GetCastAudioClip()
        {
            return _castAudioClip;
        }

        public GameObject GetApplyPowerParticlePrefab()
        {
            return _applyPowerParticleFX;
        }
        public GameObject GetCastPowerParticlePrefab()
        {
            return _castPowerParticleFX;
        }

        public PooledPrefabName GetApplyPowerPrefabEnumName()
        {
            return _applyPowerPrefabEnumName;
        }
        public PooledPrefabName GetCastPowerPrefabEnumName()
        {
            return _castPowerPrefabEnumName;
        }
    }
}