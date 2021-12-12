using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera otherCam;
    [SerializeField] private CinemachineVirtualCamera dollyCam;
    [SerializeField] private CinemachineFreeLook zoomCam;

    private void OnEnable()
    {
        CameraSwitcher.Register(otherCam);
        CameraSwitcher.Register(dollyCam);
        CameraSwitcher.SwitchCamera(otherCam);
    }
    
    private void OnDisable()
    {
        CameraSwitcher.Unregister(otherCam);
        CameraSwitcher.Unregister(dollyCam);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (CameraSwitcher.isActiveCamera(otherCam))
            {
                CameraSwitcher.SwitchCamera(dollyCam);
            } 
            else if (CameraSwitcher.isActiveCamera(dollyCam))
            {
                CameraSwitcher.SwitchCamera(otherCam);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CameraSwitcher.Unregister(otherCam);
            CameraSwitcher.Unregister(dollyCam);

            CameraSwitcher.RegisterTwo(zoomCam);
            zoomCam.Priority = 10;
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
