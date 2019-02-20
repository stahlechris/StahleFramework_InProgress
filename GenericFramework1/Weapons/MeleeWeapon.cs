//using UnityEngine;
//using Stahle.PlayerCharacter;

//namespace Stahle.Weapons
//{
//    public class Weapon : Collectable
//    {
//        WeaponSystem weaponSystem;
//        [SerializeField] PlayerController m_Player;
//        [SerializeField] SphereCollider m_HitCollider;
//        [SerializeField] AnimationClip attackAnimation;
//        [SerializeField] float meleeAttackRadius = 2f;
//        [SerializeField] float rangedAttackRadius = 0f;
//        [SerializeField] int[] variableMeleeDamage = { 0, 3 };
//        [SerializeField] float attackSpeed = 1.5f;
//        [SerializeField] float damageDelay = .5f;//to account for animation
//        [SerializeField] float criticalMultiplier = 1.75f; //1 * 1.75 = totalDamage
//        [Range(.1f, 1.0f)] [SerializeField] float criticalHitChance = 0.1f;//10% chance
//        //this variable is here until we figure out how to implement attackCooldown system
//        [SerializeField] float animationDelay = 0f;
//        AudioSource my_audioSource;
//        [SerializeField] AudioClip weaponHitNoise;
//        //bool hasCollided = false;
//        int meleeDamage = 1; //the meleeDamage the player gets (actual damage after picking variable damage)

//        #region CONST FINAL VARIABLES
//        //consider a global class that stores const finals
//        const string Liam = "Liam";
//        const string Attackable = "Attackable";
//        const string Attack = "Attack";
//        #endregion

//        public float GetAnimationDelay()
//        {
//            return animationDelay;
//        }
//        public float GetCriticalHitChance()
//        {
//            return criticalHitChance;
//        }
//        public SphereCollider GetHitCollider()
//        {
//            return m_HitCollider;
//        }
//        public float GetDamageDelay()
//        {
//            return damageDelay;
//        }
//        public int GetMeleeDamage()
//        {
//            SetMeleeDamage();
//            return meleeDamage;
//        }
//        public void SetMeleeDamage()//add 1 to the value of [1] bc exclusive
//        {
//            this.meleeDamage = Random.Range(variableMeleeDamage[0], (variableMeleeDamage[1]) + 1);
//        }
//        public float GetMeleeAttackRadius()
//        {
//            return meleeAttackRadius;
//        }
//        public float GetRangedAttackRadius()
//        {
//            return rangedAttackRadius;
//        }
//        public float GetCriticalMultiplier()
//        {
//            return criticalMultiplier;
//        }
//        public float GetAttackSpeed()
//        {
//            return attackSpeed;
//        }
//        public AnimationClip GetAttackAnimationClip()
//        {
//            attackAnimation.events = new AnimationEvent[0]; //clears animation event list,disable hits
//            return attackAnimation;
//        }

//        public override void OnPickup()
//        {
//            m_HitCollider = GetComponent<SphereCollider>();
//            my_audioSource = GetComponent<AudioSource>();
//            base.OnPickup();
//            weaponSystem = m_Player.GetComponent<WeaponSystem>();
//            weaponSystem.SetCurrentWeapon(this);
//            weaponSystem.OverrideAnimatorController();
//        }

//        void OnTriggerEnter(Collider other)
//        {
//            print(other + " entered " + this);
//            if (other.CompareTag("Player") && this.isActiveAndEnabled)
//            {
//                m_Player = other.GetComponent<PlayerController>();
//                hud.OpenMessagePanel(this, itemPickupMessage);
//                m_Player.mItemRequestingToBeCollected = this;
//            }
//            //we have been swung and an attacker entered our sphere collider
//            if (m_Player != null && m_Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Attack) && other.CompareTag(Attackable))
//            {
//                //don't attack again if we are already attacking. Attack animations have an exit time which we use as cooldowntime
//                if (!weaponSystem.isCurrentlyAttacking)
//                {
//                    my_audioSource.PlayOneShot(weaponHitNoise);
//                    weaponSystem.TestAttackTargetOnce(other.gameObject, GetMeleeDamage());
//                }
//            }
//        }

//        void OnTriggerExit(Collider other)
//        {
//            if (m_Player != null)
//            {
//                hud.CloseMessagePanel();
//                m_Player.mItemRequestingToBeCollected = null;
//            }
//        }
//    }
//}