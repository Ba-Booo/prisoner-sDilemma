using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SendCameraTransform : MonoBehaviourPunCallbacks, IPunObservable
{

    public PhotonView PV;
    public Quaternion opponentRotation;
    
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
