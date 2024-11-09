using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using Photon.Pun;

public class HeadRotation : MonoBehaviour
{

    public GameObject targetObject;
    Quaternion headRotation;
    Vector3 hr;


    void Start()
    {

        if( !PhotonNetwork.IsMasterClient )
        {
            PhotonNetwork.Instantiate("Main Camera", transform.position, transform.rotation);
        }

    }


    void Update()
    {

        if( !targetObject.activeSelf )
        {
            targetObject = GameObject.Find("Opponent");
        }

        headRotation = targetObject.GetComponent<CameraMove>().opponentRotation;
        hr = headRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(new Vector3( hr.x, hr.y + 180, hr.z ));
        Debug.Log(headRotation);
    }
}
