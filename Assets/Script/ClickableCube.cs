using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClickableCube : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    
    private SwitchCamera switchCamera;
    private WorldCameraController worldCameraController; 
    
    public GameObject CaterpillarInfoBox;
    public GameObject Canvas;


    private void Start()
    {
        switchCamera = new GameObject().AddComponent<SwitchCamera>();
        worldCameraController = new GameObject().AddComponent<WorldCameraController>();
    }
    

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.CompareTag("Button"))
            {
                print(hit.collider.name);
                Destroy(hit.transform.gameObject);
                switchCamera.SwitchToZoom();
                CaterpillarInfoBox.SetActive(true);
                worldCameraController.FixCameraPosition(6);
                Canvas.SetActive(false);
            }
        }
    }
}
