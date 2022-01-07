using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WorldCameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private CinemachineVirtualCamera cam2;
    //[SerializeField] private float speed = 0.05f;

    private bool isCam, isCam2;
    
    CinemachineTrackedDolly trackedDolly;
    private float position;
    private float pathLength;
    private float minPos = 0;
    private float maxPos;

    private float horizontal;
    private double checkTriggerPosition;
    
    public GameObject WorldText1, WorldText2, WorldText3, WorldText4, WorldText5,
        WorldText6, WorldText7, WorldText8, WorldText9, WorldText10;
    

    private void Start()
    {
        trackedDolly = cam.GetCinemachineComponent<CinemachineTrackedDolly>();

        pathLength = trackedDolly.m_Path.PathLength;
        maxPos = trackedDolly.m_Path.MaxPos;

        trackedDolly.m_PathPosition = 0;
        isCam = true; 
        isCam2 = false;
    }

    private void FixedUpdate()
    {
        // Dolly Cam Movement
        horizontal = Input.GetAxisRaw("Horizontal");
        position = trackedDolly.m_PathPosition;
        position += horizontal * Time.deltaTime;
        
        // Get position
        string posToString = position.ToString("R");
        double posToDouble = Double.Parse(posToString);
        checkTriggerPosition = Math.Round(posToDouble);
        
        trackedDolly.m_PathPosition = position;
        position = Mathf.Clamp(position, minPos, maxPos);

        // Check position
        if (isCam)
        {
            if (checkTriggerPosition == 0f)
            {
                WorldText1.SetActive(true);
                WorldText2.SetActive(false);
                Debug.Log("Track + "  + checkTriggerPosition);
            } else if (checkTriggerPosition == 1f)
            {
                WorldText1.SetActive(false);
                WorldText2.SetActive(true);
                WorldText3.SetActive(false);
                Debug.Log("Track + "  + checkTriggerPosition);
            } else if (checkTriggerPosition == 3f)
            {
                WorldText2.SetActive(false);
                WorldText3.SetActive(true);
                WorldText4.SetActive(false);
                Debug.Log("Track + "  + checkTriggerPosition);
            } else if (checkTriggerPosition == 5f)
            {
                WorldText3.SetActive(false);
                WorldText4.SetActive(true);
                Debug.Log("Track + " + checkTriggerPosition);
            } 
        }

        if (isCam2)
        {
            if (checkTriggerPosition == 0f)
            {
                WorldText5.SetActive(true);
                WorldText6.SetActive(false);
                Debug.Log("Track + "  + checkTriggerPosition);
            }
            else if (checkTriggerPosition == 2f)
            {
                WorldText5.SetActive(false);
                WorldText6.SetActive(true);
                WorldText7.SetActive(false);
                Debug.Log("Track + "  + checkTriggerPosition);
            }
            else if (checkTriggerPosition == 4f)
            {
                WorldText6.SetActive(false);
                WorldText7.SetActive(true);
                WorldText8.SetActive(false);
                Debug.Log("Track + "  + checkTriggerPosition);
            }
            else if (checkTriggerPosition == 6f)
            {
                WorldText7.SetActive(false);
                WorldText8.SetActive(true);
                WorldText9.SetActive(false);
                Debug.Log("Track + "  + checkTriggerPosition);
            }
            else if (checkTriggerPosition == 8f)
            {
                WorldText8.SetActive(false);
                WorldText9.SetActive(true);
                WorldText10.SetActive(false);
                Debug.Log("Track + "  + checkTriggerPosition);
            }
            else if (checkTriggerPosition == 10f)
            {
                WorldText9.SetActive(false);
                WorldText10.SetActive(true);
                Debug.Log("Track + "  + checkTriggerPosition);
            }
        }
        
    }
    public void DeleteText()
    {
        WorldText4.SetActive(false);
    }

    public void ChangeToCam2()
    {
        isCam = false;
        isCam2 = true; 
        
        trackedDolly = cam2.GetCinemachineComponent<CinemachineTrackedDolly>();

        pathLength = trackedDolly.m_Path.PathLength;
        maxPos = trackedDolly.m_Path.MaxPos;

        trackedDolly.m_PathPosition = 0;
    }

}








// https://www.youtube.com/watch?v=g8VpOuo5tns