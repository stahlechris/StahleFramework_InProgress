//using System.Collections;
//using UnityEngine;

//  REFACTOR TO USE ANIMATION EVENTS THAT TRIGGER FOOTSTEPS
//public class Footsteps_3D : MonoBehaviour
//{
//    //public PlayerController m_playerController;
//    //public CustomMovement m_customMovement;
//    public GameObject m_Footprints;
//    //public GameObject m_FootStepDust;
//    public AudioSource m_AudioSource;
//    public AudioClip defaultLand;
//    public Rigidbody2D rb;
//    private bool step = true;
//    //float audioStepLengthWalk = 0.5f;
//    float stepLengthRun = 0.23f;
//    //Vector3 spawnOffset = new Vector3()
//    bool HasSetCamera { get; set; }

//    private void Awake()
//    {
//        m_AudioSource = GetComponent<AudioSource>();
//        rb = GetComponent<Rigidbody2D>();
//    }

//    public void InformMoving()
//    {
//        if (step) //magnitude means && we moved
//        {
//            print("played step");
//            PlayFootstepNoise();
//            //MakeFootstepDust(collision.collider);
//        }
//    }

//    IEnumerator WaitForFootstep(float stepLength)
//    {
//        step = false;
//        yield return new WaitForSeconds(stepLength);
//        step = true;
//    }

//    private void PlayFootstepNoise()
//    {
//        m_AudioSource.volume = Random.Range(0.75f, 1f);
//        m_AudioSource.pitch = Random.Range(0.75f, 1f);
//        m_AudioSource.PlayOneShot(defaultLand);
//        StartCoroutine(WaitForFootstep(stepLengthRun));

//    }
        

//}
