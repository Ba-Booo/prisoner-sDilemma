using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using Photon.Pun;

public class HeadRotation : MonoBehaviour
{

    bool findObject = true;

    public SendCameraTransform sct;

    public GameObject targetObject;
    Quaternion headRotation;
    Vector3 hr;


    void Awake()
    {

        if( !PhotonNetwork.IsMasterClient )
        {
            PhotonNetwork.Instantiate("TurnObject", transform.position, transform.rotation);
        }

    }

    void Update()
    {

        if( PhotonNetwork.IsMasterClient && findObject )
        {
            targetObject = GameObject.Find("Opponent");
            findObject = false;
        }

        headRotation = targetObject.GetComponent<SendCameraTransform>().opponentRotation;
        hr = headRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(new Vector3( hr.x, hr.y + 180, hr.z ));
        Debug.Log(headRotation);
        
    }
}
