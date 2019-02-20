using UnityEngine;

namespace Stahle.Camera
{
    //Currently switches between FP and TP cameras
    public class CameraChanger : MonoBehaviour
    {
        [Header("Go to Edit/ProjectSetting/Input.", order = 0)]
        [Space(-10, order = 1)]
        [Header("Add another Input Axis by incrementing the Size.",order = 2)]
        [Space(-10, order = 3)]
        [Header("Change the name to ChangeCamera.",order = 4)]
        [Space(-10, order = 5)]
        [Header("Assign a Positive Button that will trigger the changing of cameras.",order = 6)]
        [Space(30, order = 7)]

        [Header("Make this the same name as the Input Axis you made.",order = 8)]
        [Tooltip("Edit/ProjectSettings/Input to create a new Input Axis.")]
        public string NameOfButtonToChangeCameras;

        [Header("Drag your ThirdPersonCamera here",order = 9)]
        public GameObject ThirdPersonCam; //0 
        [Header("Drag your FirstPersonCamera here", order = 10)]
        public GameObject FirstPersonCam; //1 

        private int camMode;

        private void Start()
        {
            if(NameOfButtonToChangeCameras == "")
            {
                Debug.LogError("You need to name the Axis that listens for camera changes!");
            }
            //Can't check Input Axes during runtime soooo.
        }
        void LateUpdate()
        {
            if (Input.GetButtonDown(NameOfButtonToChangeCameras))
            {
                ChangeCam(camMode);
            }
        }

        public void ChangeCam(int x)
        {
            camMode = x;

            if (camMode == 1)
            {
                camMode = 0;
            }
            else
            {
                camMode += 1; //it's 0, increment to 1... aka cycle through cams
            }

            CamChange();
        }

        private void CamChange()
        {
            if (camMode == 0)
            {
                ThirdPersonCam.SetActive(true);
                FirstPersonCam.SetActive(false);
                //Debug.Log("ThirdPersonCam GO active. FirstPersonCam inactive.");
            }
            if (camMode == 1)
            {
                FirstPersonCam.SetActive(true);
                ThirdPersonCam.SetActive(false);
                //Debug.Log("FirstPersonCam GO active. ThirdPersonCam inactive.");
            }
        }
    }
}