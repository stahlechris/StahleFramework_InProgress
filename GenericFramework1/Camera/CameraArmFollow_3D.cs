using UnityEngine;

namespace Stahle.Camera
{
    //Makes a Camera follow a GO tagged with "Player" in a 3D environment
    public class CameraArmFollow_3D : MonoBehaviour
    {
        #region CONST STRING FINALS
        const string PLAYER_TAG = "Player";
        const string MouseY = "Mouse Y";
        const string MouseX = "Mouse X";
        const string XboxHorizontal = "XboxHorizontal";
        const string XboxVertical = "XboxVertical";
        #endregion

        Transform _transform;

        float X;
        float Y;

        float X2;
        float Y2;

        [Tooltip("3.5 is good for both of these. Make both the same probably.")]
        [SerializeField] [Range(2.5f,4.5f)] float xSensitivity;
        [SerializeField] [Range(2.5f, 4.5f)] float ySensitivity;

        public Transform Player;

        void Awake()
        {
            _transform = transform;
        }
        void Start()
        {
            Player = GameObject.FindGameObjectWithTag(PLAYER_TAG).transform;
        }

        void LateUpdate()
        {
            //lock cam to player after every Update() has finished
            _transform.position = Player.position;
            RotateCameraIfControlAndClickDown();
            //RotateCameraIfRightThumbstick();
        }

        void RotateCameraIfControlAndClickDown()
        {
            if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftControl)) //if contrl + click
            {
                _transform.Rotate(new Vector3(-Input.GetAxis(MouseY) * ySensitivity, Input.GetAxis(MouseX) * xSensitivity, 0));
                X = _transform.rotation.eulerAngles.x;
                Y = _transform.rotation.eulerAngles.y;
                _transform.rotation = Quaternion.Euler(X, Y, 0);
            }
        }
        /*xbox CameraRotate Method
        void RotateCameraIfRightThumbstick()
        {
            if (Global.XBOX_CONTROLLER_PLUGGED_IN)
            {
                _transform.Rotate(new Vector3(-Input.GetAxis(XboxHorizontal) * xSensitivity, Input.GetAxis(XboxVertical) * ySensitivity, 0));
                X2 = _transform.rotation.eulerAngles.x;
                Y2 = _transform.rotation.eulerAngles.y;
                _transform.rotation = Quaternion.Euler(X2, Y2, 0);
            }
        }
        #region XBOX_Mapping
        HORIZONTAL: 
        gravity = 0
        dead = 0.2
        sensitivity = 0.5
        invert = checked
        Joystick Axis
        4th Axis(joysticks)
        Get Motion from all joysticks

        VERTICAL: 
        gravity = 0
        dead = 0.2
        sensitivity = 0.5
        invert = not checked
        Joystick Axis
        3rd Axis(joysticks)
        Get Motion from all joysticks
        #endregion       
        */
    }
}
