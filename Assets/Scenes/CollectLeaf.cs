using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLeaf : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    public GameObject caterpillar; 
    
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

        if (caterpillar.transform.localScale == new Vector3(0.13f, 0.13f, 0.13f))
        {
            print("Fat enough for me.");
        }
    }
}
