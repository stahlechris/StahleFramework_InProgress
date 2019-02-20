using UnityEngine;
//using MEC;

namespace Stahle.Misc
{
    //Put this on a GameObject to make it levitate
    public class Levitate : MonoBehaviour
    {
        [Header("Tick to enable an Update() and begin Levitating.")]
        public bool doLevitate = false;

        [Header("Set frequency of Sin Wave used to Levitate.")]
        [Tooltip("Frequency is how fast a vibration occurs.")]
        public float frequency = 1f;

        [Header("Set amplitude of Sin Wave used to Levitate.")]
        [Tooltip("Amplitude is the amount up and down from the middle.")]
        public float amplitude = 0.5f;

        Transform _transform;
        Vector3 _thingToLevitate;
        Vector3 _tempLevitate;


        void Start()
        {
            _transform = transform;
            _thingToLevitate = _transform.position;
            //Timing.RunCoroutine(CoroutineUpdate.EmulateUpdate(_Update, this);
        }

        // void _Update()
        void Update()
        {
            if (doLevitate)
            {
                _tempLevitate = _thingToLevitate;
                _tempLevitate.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

                _transform.position = _tempLevitate;
            }
        }

    }
}