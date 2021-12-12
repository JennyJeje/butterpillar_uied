using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class LookAtText : MonoBehaviour
{
    public GameObject cam;
    void Update()
    {
        transform.LookAt(cam.transform);
    }
}
