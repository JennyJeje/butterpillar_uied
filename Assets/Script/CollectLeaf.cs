using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLeaf : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    public GameObject caterpillar;
    public GameObject TextGameObject;

    public ParticleSystem ps;


    private void Start()
    {
       // ps.GetComponent<ParticleSystem>();
       // ps.Stop();
    }

    void Update () 
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.CompareTag("Leaf"))
            {
                print(hit.collider.name);
                Destroy(hit.transform.gameObject);
                caterpillar.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            }
        }

        if (caterpillar.transform.localScale == new Vector3(0.09f, 0.09f, 0.09f))
        {
            Destroy(TextGameObject);
            ps.Play();
        }
    }
}
