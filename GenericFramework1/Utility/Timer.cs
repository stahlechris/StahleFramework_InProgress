using UnityEngine;
using System.Collections.Generic;
using MEC;

namespace Stahle.Utility
{
    public class Timer : MonoBehaviour
    {
        public float ElapsedTime = 0.0f;
        public bool TimerOn = false;

        public IEnumerator<float> BeginTimer(int duration)
        {
            TimerOn = true;
            while (ElapsedTime <= duration)
            {
                ElapsedTime += Time.deltaTime;
                yield return Timing.WaitForOneFrame;
            }
            TimerOn = false;
        }
    }
}