using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class WorldCameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private float speed;
    public CinemachineTrackedDolly trackedDolly;

    private float position;
    private float horizontal;

    public void Start()
    {
        trackedDolly = cam.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        position = trackedDolly.m_PathPosition;

        if (Input.mouseScrollDelta.y == -1 || Input.GetKeyDown(KeyCode.DownArrow))
        {
            position -= horizontal * speed * Time.deltaTime;
        } else if (Input.mouseScrollDelta.y == +1 || Input.GetKeyDown(KeyCode.UpArrow))
        {
            position += horizontal * speed * Time.deltaTime;
        }
        
        // position = Mathf.Clamp01(position);
        trackedDolly.m_PathPosition = position;
    }
}








// https://www.youtube.com/watch?v=g8VpOuo5tns