using System.Collections.Generic;
using UnityEngine;
using MEC;

namespace Stahle.Utility
{
    public static class CoroutineUpdate
    {
        public static IEnumerator<float> EmulateUpdate(System.Action func, MonoBehaviour scr)
        {
            yield return Timing.WaitForOneFrame;

            while (scr.gameObject != null)
            {
                if (scr.gameObject.activeInHierarchy && scr.enabled)
                {
                    func();
                }
                yield return Timing.WaitForOneFrame;
            }
            //Stopped emulating an Update()
        }
    }
}
//http://trinary.tech/category/mec/