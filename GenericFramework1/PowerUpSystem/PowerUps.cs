using UnityEngine;

namespace Stahle.PowerUpSystem
{
    public class PowerUps : MonoBehaviour
    {
        [SerializeField] PowerUp_Config _powerUps;

        void Start()
        {

        }
        public void AttachPowerUps()
        {
            _powerUps.AttachSpecialAbilityTo(gameObject);
        }
        public void AttemptPowerUp(GameObject target)
        {
            _powerUps.Use(target);
        }
    }
}