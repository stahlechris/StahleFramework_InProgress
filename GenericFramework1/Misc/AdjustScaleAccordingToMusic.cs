using UnityEngine;

namespace Stahle.Audio
{
    public class AdjustScaleAccordingToMusic : MonoBehaviour
    {
        public bool doBehavior;

        public int qSamples = 1024;
        public float refValue = 0.1f;
        public float rmsValue;
        public float dbValue;
        public float Volume = 3;

        private float[] samples;

        void Start()
        {
            samples = new float[qSamples];
        }

        // Update is called once per frame
        void Update()
        {
            if (doBehavior)
            {
                GetVolume();
                transform.localScale = new Vector3(transform.localScale.x, Volume * rmsValue, transform.localScale.z);
            }
        }

        private void GetVolume()
        {
            AudioManager.SharedInstance.music_AudioSource.GetOutputData(samples, 0);
            int i = 0;
            float sum = 0.0f;

            for(i = 0; i<qSamples;i++)
            {
                //sum is the square samples[i]
                sum += samples[i] * samples[i]; 
            }
            //rms is the sqrt of the average of samples
            rmsValue = Mathf.Sqrt(sum / qSamples);

            //calculate DB
            dbValue = 20 * Mathf.Log10(rmsValue / refValue);

            //always stay at -160
            if (dbValue < -160)
                dbValue = -160;
        }
    }
}