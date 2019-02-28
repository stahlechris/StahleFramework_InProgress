using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stahle.Utility;

namespace Stahle.Camera
{
    public class FreelyRotateTheCamera : MonoBehaviour
    {
        Transform _transform;
        const string MouseY = "Mouse Y";
        const string MouseX = "Mouse X";
        const string XboxHorizontal = "XboxHorizontal";
        const string XboxVertical = "XboxVertical";

        float X;
        float Y;

        float X2;
        float Y2;

        private void Start()
        {
            _transform = transform;
        }

        void LateUpdate()
        {
            RotateCameraIfControlAndClickDown();
            RotateCameraIfRightThumbstick();
        }



        void RotateCameraIfControlAndClickDown()
        {
            if (Lerper.SharedInstance.HasFinishedRotating)
            {
                if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftControl)) //if contrl + click
                {                                                       //sensitivity             //sensitivity
                    _transform.Rotate(new Vector3(-Input.GetAxis(MouseY) * 3.5f, Input.GetAxis(MouseX) * 3.5f, 0));
                    X = _transform.rotation.eulerAngles.x;
                    Y = _transform.rotation.eulerAngles.y;
                    _transform.rotation = Quaternion.Euler(X, Y, 0);
                }
            }
        }

        void RotateCameraIfRightThumbstick()
        {
            if (AdvancedLerper.SharedInstance.HasFinishedRotating)
            {
                _transform.Rotate(new Vector3(-Input.GetAxis(XboxHorizontal) * 3.5f, Input.GetAxis(XboxVertical) * 3.5f, 0));
                X2 = _transform.rotation.eulerAngles.x;
                Y2 = _transform.rotation.eulerAngles.y;
                _transform.rotation = Quaternion.Euler(X2, Y2, 0);
            }
        }
    }
}