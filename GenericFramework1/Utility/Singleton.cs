using UnityEngine;

namespace Stahle.Utility
{
    //A Singleton that gets Destroyed when switching scenes
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T SharedInstance 
        { 
            get; 
            protected set; 
        }

        public static bool InstanceExists
        {
            get 
            { 
                return SharedInstance != null; 
            }
        }

        protected virtual void Awake()
        {
            if (InstanceExists)
            {
                Destroy(gameObject);
            }
            else
            {
                SharedInstance = (T)this;
            }
        }

        protected virtual void OnDestroy()
        {
            if (SharedInstance == this)
            {
                SharedInstance = null;
            }
        }
    }
}