using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLeaf : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    public GameObject caterpillar;
    private float number;
    
    public GameObject WorldText10, WorldText11; 
    
    void Update () 
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.CompareTag("Leaf"))
            {
                number = 0.4f;
                print(hit.collider.name);
                Destroy(hit.transform.gameObject);
                caterpillar.transform.localScale += new Vector3(number, number, number);
            }
        }

        if (caterpillar.transform.localScale == new Vector3(7, 7, 7))
        {
            print("Fat enough for me.");
            WorldText10.SetActive(false);
            WorldText11.SetActive(true);
        }
    }
}
