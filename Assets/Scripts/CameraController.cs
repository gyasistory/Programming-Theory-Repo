using Cinemachine;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        public CinemachineVirtualCameraBase overviewCamera;
        public CinemachineVirtualCameraBase cowboyCamera;
        public CinemachineVirtualCameraBase ladyCamera;

        public void EnableCowboyCamera()
        {
            // Activate CowboyCamera
            cowboyCamera.Priority = 100;

            // Deactivate other cameras
            overviewCamera.Priority = -100;
            ladyCamera.Priority = -100;

        }

        public void EnableOverviewCamera()
        {
            // Activate CowboyCamera
            overviewCamera.Priority = 100;

            // Deactivate other cameras
            cowboyCamera.Priority = -100;
            ladyCamera.Priority = -100;

        }

        public void EnableLadyCamera()
        {
            // Activate CowboyCamera
            ladyCamera.Priority = 100;

            // Deactivate other cameras
            overviewCamera.Priority = -100;
            cowboyCamera.Priority = -100;

        }
    }
}