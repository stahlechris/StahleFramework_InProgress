using UnityEngine;
using System.Collections.Generic;
using MEC; //3rd party Trinary Software plugin called MoreEffectiveCoroutines

namespace Stahle.Utility
{
    //Use this to Lerp things so it doesn't muddy up your class that needs a Lerp
    public class Lerper : MonoBehaviour
    {
        public void Lerp(Transform thingToLerp, Vector3 startingPos, Vector3 endingPos, float timeItTakesToLerp)
        {
            StartCoroutine(LerpItGood(thingToLerp, startingPos, endingPos, timeItTakesToLerp));
        }
        public void Lerp(Transform thingToLerp, Quaternion startingRot, Quaternion endingRot, float timeItTakesToLerp)
        {
            StartCoroutine(LerpItGood(thingToLerp, startingRot, endingRot, timeItTakesToLerp));
        }

        #region POSITIONAL LERP
        private IEnumerator<float> LerpItGood(Transform thingToLerp, Vector3 startingPos, Vector3 endingPos, float timeItTakesToLerp)
        {
            float elapsedTime = 0.0f;
            Vector3 startingPosition = startingPos;
            Vector3 endingPosition = endingPos;


            while (elapsedTime < timeItTakesToLerp)
            {
                thingToLerp.localPosition = Vector3.Lerp(startingPosition, endingPosition, (elapsedTime / timeItTakesToLerp));
                elapsedTime += Time.deltaTime;
                yield return Timing.WaitForOneFrame;
            }
            //Must snap into place bc Lerp will be off due to floating point imprecision!
            thingToLerp.localPosition = endingPosition;
        }
        #endregion

        #region ROTATIONAL LERP
        private IEnumerator<float> LerpItGood(Transform thingToLerp, Quaternion startingRot, Quaternion endingRot, float timeItTakesToLerp)
        {
            float elapsedTime = 0.0f;
            Quaternion startingRotation = startingRot;
            Quaternion endingRotation = endingRot;


            while (elapsedTime < timeItTakesToLerp)
            {
                thingToLerp.rotation = Quaternion.Lerp(startingRotation, endingRotation, (elapsedTime / timeItTakesToLerp));
                elapsedTime += Time.deltaTime;
                yield return Timing.WaitForOneFrame;
            }
            //Must snap into place bc Lerp will be off due to floating point imprecision!
            thingToLerp.rotation = endingRotation;
        }
        #endregion
    }
}