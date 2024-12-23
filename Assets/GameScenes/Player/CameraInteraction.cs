using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{
    
    //클립보드
    public static bool ClipboardSituation;
    public float range;
    RaycastHit hit;
    public GameObject OX;
    public BoxCollider OObject;
    public BoxCollider XObject;

    public bool choice;
    public bool result = false;

    void Update()
    {
        
        //클립보드 들기
        if( Input.GetMouseButtonUp(0) && Physics.Raycast(transform.position, transform.forward, out hit) && !ClipboardSituation )
        {
            ClipboardSituation = true;
        }
        else if( Input.GetKeyDown( KeyCode.Escape ) )
        {
            ClipboardSituation = false;
        }

        if( ClipboardSituation && !result)
        {
            GameObject.Find("Clipboard").GetComponent<ClipboardMove>().Execution();
            OObject.enabled = true;
            XObject.enabled = true;
            OX.SetActive(true); 
        }
        else
        {
            GameObject.Find("Clipboard").GetComponent<ClipboardMove>().Restore();
            OObject.enabled = false;
            XObject.enabled = false;
            OX.SetActive(false); 
        }

        //ox
        if( Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit) && hit.transform.gameObject.name == "O" )         //o 
        {
            ClipboardSituation = false;
            choice = true;
            result = true;
        }
        else if( Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit) && hit.transform.gameObject.name == "X" )    //x
        {
            ClipboardSituation = false;
            choice = false;
            result = true;
        }

    }
}
