using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CinemachineVirtualCameraBase overviewCamera;
    public CinemachineVirtualCameraBase cowboyCamera;
    public CinemachineVirtualCameraBase ladyCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
