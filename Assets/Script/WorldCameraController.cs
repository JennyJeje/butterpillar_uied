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
        // Dolly Cam Movement mit Pfeiltasten
        horizontal = Input.GetAxisRaw("Horizontal"); 
        horizontal = Input.GetAxisRaw("Horizontal"); 
        position += horizontal * Time.deltaTime; 

        // Dolly Cam Movement mit Mouse Scrollwheel
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0) // Forward
        {
            trackedDolly.m_PathPosition += 3f * Time.deltaTime;
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0) // Backward
        {
            trackedDolly.m_PathPosition -= 3f * Time.deltaTime;
        }
        
        // Get position
        position = trackedDolly.m_PathPosition;
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
            } else if (checkTriggerPosition == 1f || checkTriggerPosition == 2f)
            {
                WorldText1.SetActive(false);
                WorldText2.SetActive(true);
                WorldText3.SetActive(false);
                //Debug.Log("Track + "  + checkTriggerPosition);
            } else if (checkTriggerPosition == 3f || checkTriggerPosition == 4f)
            {
                WorldText2.SetActive(false);
                WorldText3.SetActive(true);
                WorldText4.SetActive(false);
            } else if (checkTriggerPosition == 5f)
            {
                WorldText3.SetActive(false);
                WorldText4.SetActive(true);
            } 
        }

        if (isCam2)
        {
            if (checkTriggerPosition == 0f || checkTriggerPosition == 1f)
            {
                WorldText5.SetActive(true);
                WorldText6.SetActive(false);
            }
            else if (checkTriggerPosition == 2f || checkTriggerPosition == 3f)
            {
                WorldText5.SetActive(false);
                WorldText6.SetActive(true);
                WorldText7.SetActive(false);
            }
            else if (checkTriggerPosition == 4f || checkTriggerPosition == 5f)
            {
                WorldText6.SetActive(false);
                WorldText7.SetActive(true);
                WorldText8.SetActive(false);
            }
            else if (checkTriggerPosition == 6f || checkTriggerPosition == 7f)
            {
                WorldText7.SetActive(false);
                WorldText8.SetActive(true);
                WorldText9.SetActive(false);
            }
            else if (checkTriggerPosition == 8f || checkTriggerPosition == 9f)
            {
                WorldText8.SetActive(false);
                WorldText9.SetActive(true);
                WorldText10.SetActive(false);
            }
            else if (checkTriggerPosition == 10f)
            {
                WorldText9.SetActive(false);
                WorldText10.SetActive(true);
            }
        }
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

    public void FixCameraPosition(int position)
    {
        trackedDolly.m_PathPosition = position;
    }
}