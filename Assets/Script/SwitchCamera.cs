using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera dollyCam;
    [SerializeField] private CinemachineVirtualCamera dollyCam2;
    [SerializeField] private CinemachineFreeLook zoomCam;

    public GameObject butterpillarCanvas; 
    private void OnEnable()
    {
        CameraSwitcher.Register(dollyCam2);
        CameraSwitcher.Register(dollyCam);
        CameraSwitcher.RegisterTwo(zoomCam);

        CameraSwitcher.SwitchCamera(dollyCam);
    }
    
    private void OnDisable()
    {
        CameraSwitcher.Unregister(dollyCam2);
        CameraSwitcher.Unregister(dollyCam);
    }

    private void Update()
    {
        
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            butterpillarCanvas.SetActive(false);

            if (CameraSwitcher.isActiveCamera(dollyCam2))
            {
                CameraSwitcher.SwitchCamera(dollyCam);
            } 
            else if (CameraSwitcher.isActiveCamera(dollyCam))
            {
                CameraSwitcher.SwitchCamera(dollyCam2);
            }
        }
        
        // For testing
        if (Input.GetKeyDown(KeyCode.Z))
        {
            butterpillarCanvas.SetActive(true);

            dollyCam2.Priority = 0;
            dollyCam.Priority = 0;
            zoomCam.Priority = 9;
        }
        */
    }
    
    public void SwitchToZoom()
    {
        butterpillarCanvas.SetActive(true);

        dollyCam2.Priority = 0;
        dollyCam.Priority = 0;
        zoomCam.Priority = 9;
    }

    public void SwitchToCam2()
    {
        if (CameraSwitcher.isActiveCamera(dollyCam))
        {
            butterpillarCanvas.SetActive(false);
            CameraSwitcher.SwitchCamera(dollyCam2);
        }
    }
}



public static class CameraSwitcher
{
    private static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    private static List<CinemachineFreeLook> freecameras = new List<CinemachineFreeLook>();

    
    public static CinemachineVirtualCamera ActiveCamera = null;

    
    public static bool isActiveCamera(CinemachineVirtualCamera cam)
    {
        return cam == ActiveCamera; 
    }
    
    public static void SwitchCamera(CinemachineVirtualCamera cam)
    {
        cam.Priority = 10;
        ActiveCamera = cam;
        foreach (CinemachineVirtualCamera c in cameras)
        {
            if (c != cam && c.Priority != 0)
            {
                c.Priority = 0; 
            }
        }
    }

    public static void Register(CinemachineVirtualCamera cam)
    {
        cameras.Add(cam);
        Debug.Log("Camera is registred." + cam);
    }

    public static void Unregister(CinemachineVirtualCamera cam)
    {
        cameras.Remove(cam);
        Debug.Log("Camera is unregistred." + cam);
    }
    
    public static void RegisterTwo(CinemachineFreeLook cam)
    {
        freecameras.Add(cam);
    }

}
