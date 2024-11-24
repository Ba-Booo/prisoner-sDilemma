using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{

    //포톤
    ///public PhotonView PV;
    
    //클립보드
    public static bool ClipboardSituation;
    public float range;
    RaycastHit hit;
    public BoxCollider OObject;
    public BoxCollider XObject;

    void Update()
    {
        
        //클립보드 들기
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
            OObject.enabled = true;
            XObject.enabled = true;
        }
        else
        {
            GameObject.Find("Clipboard").GetComponent<ClipboardMove>().Restore();
            OObject.enabled = false;
            XObject.enabled = false;
        }

        //ox
        // if( Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit) && !ClipboardSituation )
        // {
        //     ClipboardSituation = true;
        // }
        


    }
}
