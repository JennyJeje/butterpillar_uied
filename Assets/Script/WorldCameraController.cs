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
    [SerializeField] private float speed = 2f;

    CinemachineTrackedDolly trackedDolly;
    private float position;
    private float pathLength;
    private float minPos = 0;
    private float maxPos;

    private float horizontal;
    private double checkTriggerPosition;

    public GameObject GameObject; 

    private void Start()
    {
        trackedDolly = cam.GetCinemachineComponent<CinemachineTrackedDolly>();
        pathLength = trackedDolly.m_Path.PathLength;
        maxPos = trackedDolly.m_Path.MaxPos;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        position = trackedDolly.m_PathPosition;
        position += horizontal * speed * Time.deltaTime;
        
        string posToString = position.ToString("R");
        double posToDouble = Double.Parse(posToString);
        checkTriggerPosition = Math.Round(posToDouble);
        
        trackedDolly.m_PathPosition = position;
        position = Mathf.Clamp(position, minPos, maxPos);

        if (checkTriggerPosition == 1f)
        {
            GameObject.SetActive(false);
            Debug.Log("Track 1 + "  + checkTriggerPosition);
        } else if (checkTriggerPosition == 3f)
        {
            GameObject.SetActive(true);
            Debug.Log("Track 3 + " + checkTriggerPosition);
        }
        
        
        /*
        if (position > trackedDolly.m_Path.MinPos && (Input.mouseScrollDelta.y == -1 || Input.GetKeyDown(KeyCode.DownArrow)) )
        {
            position -= horizontal * speed * Time.deltaTime;
            trackedDolly.m_PathPosition = position;

            Debug.Log("DownArrowKey detected." + position);
        }
        else if (position < trackedDolly.m_Path.MaxPos && (Input.mouseScrollDelta.y == +1 || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            position += horizontal * speed * Time.deltaTime;
            trackedDolly.m_PathPosition = position;

            Debug.Log("UpArrowKey detected." + position);
        }
        
        */

    }
}








// https://www.youtube.com/watch?v=g8VpOuo5tns