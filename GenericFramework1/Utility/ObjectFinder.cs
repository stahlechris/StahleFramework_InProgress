using UnityEngine;

namespace Stahle.Utility
{
    //Use this to grab popular GO's that are used by multiple classes
    //This eliminates a .Find() during runtime
    public class ObjectFinder : Singleton<ObjectFinder>
    {
        #region Player Components
        public static Transform playerTransform;
        #endregion

        #region Systems
        #endregion

        protected override void Awake()
        {
            #region Player Components
            playerTransform = GameObject.FindWithTag("Player").transform;
            #endregion

            #region Systems
            #endregion
        }
    }
}