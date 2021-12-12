using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickableText : MonoBehaviour
{
    public GameObject titleObj;
    public TMP_Text descObj;

    public string titleText;
    public string descText;

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) {  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
            if (Physics.Raycast(ray, out hit)) {  
                if (hit.transform.name == "Kopf") {  
                    ChangeText(titleText, descText);
                    Debug.Log("yes");
                }  
            }  
        }  
    }
    
    void ChangeText(string title, string desc)
    {
        titleObj.transform.Find("TitleText").GetComponent<TextMeshPro>().text = title;
        descObj.transform.Find("DescText").GetComponent<TextMeshPro>().text = desc;

    }
}
