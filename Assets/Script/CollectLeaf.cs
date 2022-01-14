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
    
    public GameObject BlackScreen;
    public GameObject BlackScreen2;
    public GameObject WorldText11;
    public GameObject WorldText14;
    
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
            StartCoroutine(ShowAndHide());
            caterpillar.transform.position = new Vector3(275.993f, 36f, 246.5f);
            caterpillar.transform.rotation = Quaternion.Euler(-90.4f,73.961f,49.9f);
            ps.Play();
        }

        if (WorldText14.activeSelf)
        {
            Destroy(caterpillar, 2f);
            WorldText14.SetActive(false);
            StartCoroutine(ShowBreakText());
        }
        
    }
    
    IEnumerator ShowAndHide()
    {
        BlackScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        BlackScreen.SetActive(false);
        yield return new WaitForSeconds(3);
        WorldText11.SetActive(true);
    }

    IEnumerator ShowBreakText()
    {
        yield return new WaitForSeconds(3);
        BlackScreen2.SetActive(true);
        yield return new WaitForSeconds(3);

        if (ps.isPlaying)
        {
            //ps.Stop();
        }
    }
    
    
    
}
