using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SendCameraTransform : MonoBehaviourPunCallbacks, IPunObservable
{

    public int clone = 0;

    GameObject cameraRotation;

    public PhotonView pv;
    public Quaternion opponentRotation;

    void Awake()
    {
        cameraRotation = GameObject.Find("MainCamera");
    }

    void Start()
    {
        if( !pv.IsMine )
        {
            this.gameObject.name = "Opponent";
            clone = 1;
        }
    }

    void Update()
    {
        transform.rotation = cameraRotation.transform.rotation;
    }
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if( stream.IsWriting )
        {
            stream.SendNext( this.gameObject.transform.rotation );
        }
        else
        {
            opponentRotation = (Quaternion)stream.ReceiveNext();
        }

    }

}
