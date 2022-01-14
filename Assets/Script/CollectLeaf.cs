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
    
    public GameObject currentFrame;
    public GameObject WorldText11;

    public ParticleSystem ps;


    void Start()
    {
       ps.GetComponent<ParticleSystem>();
       ps.Stop();
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

        if (!ps.isPlaying && caterpillar.transform.localScale == new Vector3(0.09f, 0.09f, 0.09f))
        {
            Destroy(TextGameObject);
            StartCoroutine(ShowAndHide(3.5f));
            caterpillar.transform.position = new Vector3(275.993f, 36f, 246.5f);
            caterpillar.transform.rotation = Quaternion.Euler(-90.4f,73.961f,49.9f);
            ps.Play();
        }
    }
    
    IEnumerator ShowAndHide(float delay)
    {
        currentFrame.SetActive(true);
        yield return new WaitForSeconds(delay);
        currentFrame.SetActive(false);
        WorldText11.SetActive(true);
    }

    
}
