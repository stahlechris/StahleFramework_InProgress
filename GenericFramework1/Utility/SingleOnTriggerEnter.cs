using UnityEngine;

//This script goes on root objects that have children with trigger colliders
//OnTriggerEnter will only be called once now.
namespace Stahle.Utility
{
    public class SingleOnTriggerEnter : MonoBehaviour
    {
        bool hasEntered = false;

        private void OnTriggerEnter(Collider other)
        {
            //print(other + " entered " + this);
            if (!hasEntered)
            {
                //case 1: player enters
                if (other.CompareTag("Player"))
                {
                    hasEntered = true;
                }
            }
        }
    }
}