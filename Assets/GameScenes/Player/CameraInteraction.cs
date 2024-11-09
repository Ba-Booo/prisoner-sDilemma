using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{

    public static bool ClipboardSituation;

    public float range;

    RaycastHit hit;

    void Update()
    {

        if( Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit) && !ClipboardSituation )
        {
            ClipboardSituation = true;
        }
        else if( Input.GetKeyDown( KeyCode.Escape ) )
        {
            ClipboardSituation = false;
        }

        if( ClipboardSituation )
        {
            GameObject.Find("Clipboard").GetComponent<ClipboardMove>().Execution();
        }
        else
        {
            GameObject.Find("Clipboard").GetComponent<ClipboardMove>().Restore();
        }


    }
}
