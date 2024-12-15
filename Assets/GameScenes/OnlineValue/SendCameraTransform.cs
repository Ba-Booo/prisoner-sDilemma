using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SendCameraTransform : MonoBehaviourPunCallbacks, IPunObservable
{

    // 카메라
    public int clone = 0;

    GameObject cameraRotation;

    public PhotonView pv;
    public Quaternion opponentRotation;

    // //점수관련
    // public CameraInteraction ci;

    // bool otherResult = false;
    // public bool otherChoice = false;

    // public int playersentence;
    // public int othersentence;
    


    // int Calculate( bool me, bool other )
    // {

    //     int result = 5;

    //     if( me && other )
    //     {
    //         result = 1;
    //     }
    //     else if( !me && other )
    //     {
    //         result = 0;
    //     }
    //     else if( me && !other )
    //     {
    //         result = 10;
    //     }

    //     return result;
    // }



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

        // if(otherResult && otherResult)
        // {
        //     playersentence = Calculate( ci.choice, otherChoice );
        // }

    }
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if( stream.IsWriting )
        {

            stream.SendNext( this.gameObject.transform.rotation );

            // if(ci.result)
            // {
            //     stream.SendNext( ci.choice );
            // }
            // if(otherResult && otherResult)
            // {
            //     stream.SendNext( playersentence );
            // }

        }
        else
        {

            opponentRotation = (Quaternion)stream.ReceiveNext();
            // otherChoice = (bool)stream.ReceiveNext();
            // otherResult = (bool)stream.ReceiveNext();
            
            // othersentence = (int)stream.ReceiveNext();
            
        }

    }

}
