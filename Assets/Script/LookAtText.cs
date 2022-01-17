using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class LookAtText : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        transform.LookAt(mainCamera.transform);
    }
}
