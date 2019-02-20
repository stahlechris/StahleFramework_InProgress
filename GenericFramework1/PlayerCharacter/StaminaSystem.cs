using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Stahle.Utility; //For ObjectFinder.cs
using MEC;

namespace Stahle.PlayerCharacter
{
    public class StaminaSystem : MonoBehaviour
    {
        [Header("How much stamina does it cost to jump?")]
        [SerializeField] const int JUMP_COST = 5;

        [Header("How much stamina does it cost to sprint/sec?")]
        [SerializeField] const float SPRINT_COST = 1f;
        //add more physical action costs here

        [Header("Drag in the playermovement script")]
        [SerializeField] PlayerMovement_3D _playerMovement;

        [Header("What image's fill amount do I adjust?")]
        [SerializeField] Image _imageStamina; //dragged in foreground

        [Header("What's the max amount of stamina the player has?")]
        [SerializeField] float _maxStamina = 100;

        [Header("How much stamina does the player start with?")]
        [SerializeField] float _currentStamina = 99;

        [Header("How much stamina does the player regenerate/sec?")]
        [SerializeField] float _staminaRegenerationRate = 15f;

        [Header("How long should the player be affected by slow/stop if out of stamina?")]
        [SerializeField] float timeItTakesToCatchMyBreath = 2f;

        public bool isCatchingBreath = false;
        public bool isSprinting = false;
        
        public float StaminaAsPercentage
        {
            get
            {
                return _currentStamina / (float)_maxStamina;
            }
        }

        private void Start()
        {
            //_playerMovement = ObjectFinder.PlayerGameObject.GetComponent<PlayerMovement_3D>();
            //Timing.RunCoroutine(_Update, this);
        }

        //void _Update()
        void Update()
        {
            if (_currentStamina < _maxStamina)
            {
                RegenerateStaminaOverTime();
                UpdateStaminaWheel();
            }
        }

        void UpdateStaminaWheel()
        {
            _imageStamina.fillAmount = StaminaAsPercentage;
        }


        void RegenerateStaminaOverTime()
        {
            var staminaToAdd = _staminaRegenerationRate * Time.deltaTime;
            _currentStamina = Mathf.Clamp(_currentStamina + staminaToAdd, 0, _maxStamina); //clamp so it can't go above or below
        }

        void ConsumeStamina(float amountToConsume)
        {
            float updatedStamina = (_currentStamina - amountToConsume);
            _currentStamina = Mathf.Clamp(updatedStamina, 0, _maxStamina);

            UpdateStaminaWheel();
            RegenerateStaminaOverTime();
        }

        public bool AttemptJump()
        {
            if (JUMP_COST <= _currentStamina)
            {
                ConsumeStamina(JUMP_COST);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AttemptSprint()
        {
            if (SPRINT_COST <= _currentStamina)
            {
                isSprinting = true;
                ConsumeStamina(SPRINT_COST);
                return true;
            }
            else
            {
                isSprinting = false;
                //_playerMovement.m_MoveSpeedMultiplier = 0.5f;
                //_playerMovement.m_AnimSpeedMultiplier = 0.5f;

                StartCoroutine(CatchMyBreath());
                return false;
            }
        }

        public IEnumerator<float> CatchMyBreath()
        {
            isSprinting = false;
            isCatchingBreath = true;
            yield return Timing.WaitForSeconds(timeItTakesToCatchMyBreath);
            isCatchingBreath = false;
            //_playerMovement.m_MoveSpeedMultiplier = 1f;
           // _playerMovement.m_AnimSpeedMultiplier = 1f;

            //suspend movement
            //play panting animation
            //play panting sound
        }
    }
}