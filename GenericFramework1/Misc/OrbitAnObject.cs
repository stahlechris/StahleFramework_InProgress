using UnityEngine;
//using MEC;
//using Stahle.Utility;

namespace Stahle.Misc
{
    //Place this on a GameObject to make it orbit another Gameobject
    public class OrbitAnObject : MonoBehaviour
    {
        [Header("Drag in the GameObject that will be orbitted by this.")]
        public GameObject ThingToOrbit;
        private Transform center;

        [Header("What is the radius of this thing's orbit?")]
        public float radius = 30f;
        [Header("How fast does this thing complete an orbit?")]
        public float radiusSpeed = 0.5f;

        [Header("How fast does this thing orbit the other thing?")]
        public float rotationSpeed = -20f;

        private Transform _center;
        private Vector3 _desiredPosition;
        private Vector3 _axis = Vector3.up;
        Transform _transform;

        void Start()
        {
            _transform = transform;
            _center = ThingToOrbit.transform;
            _transform.position = (_transform.position - _center.position).normalized * radius + _center.position;
            //Timing.RunCoroutine(_Update, this);
        }

        //private void _Update()
        private void Update()
        {
            _transform.RotateAround(_center.position, _axis, rotationSpeed * Time.deltaTime);
            _desiredPosition = (_transform.position - _center.position).normalized * radius + _center.position;
            _transform.position = Vector3.MoveTowards(_transform.position, _desiredPosition, Time.deltaTime * radiusSpeed);
        }
    }
}