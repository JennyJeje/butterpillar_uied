using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectLeaf : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    public GameObject caterpillar;
    public GameObject TextGameObject;
    public GameObject CanvasObject;
    
    public GameObject BlackScreen;
    public GameObject BlackScreen2;
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
            Destroy(CanvasObject);
            StartCoroutine(ShowAndHide());
            caterpillar.transform.position = new Vector3(275.993f, 36.2f, 246.5f);
            caterpillar.transform.rotation = Quaternion.Euler(0f,190.46f,-73.641f);
            ps.Play();
        }
    }

    public void MoveToFinalScene()
    {
        StartCoroutine(ShowBreakText());
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
        Destroy(caterpillar);
        yield return new WaitForSeconds(3);
        BlackScreen2.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    
    
    
}
