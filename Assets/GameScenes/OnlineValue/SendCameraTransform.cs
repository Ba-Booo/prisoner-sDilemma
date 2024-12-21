using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class SendCameraTransform : MonoBehaviourPunCallbacks, IPunObservable
{

    // 카메라
    public int clone = 0;

    GameObject cameraRotation;

    public PhotonView pv;
    public Quaternion opponentRotation;

    //점수관련
    public CameraInteraction ci;

    bool otherResult = false;
    bool otherChoice = false;

    public int playersentence;
    public int othersentence;

    public TextMeshProUGUI guideText;

    int Calculate( bool me, bool other, TextMeshProUGUI gt )
    {

        int result = 5;

        if( me && other )
        {
            result = 1;
            gt.text = "믿음을 저버리지\n않았습니다";
        }
        else if( !me && other )
        {
            result = 0;
            gt.text = "배신하셨습니다";
        }
        else if( me && !other )
        {
            result = 10;
            gt.text = "배신당하셨습니다";
        }
        else
        {
            result = 5;
            gt.text = "서로 배신하였습니다";
        }

        return result;
    }



    void Awake()
    {
        cameraRotation = GameObject.Find("MainCamera");
    }

    void Start()
    {
        
        ci = GameObject.Find("MainCamera").GetComponent<CameraInteraction>();
        guideText = GameObject.Find("GuideText").GetComponent<TextMeshProUGUI>();


        if( !pv.IsMine )
        {
            this.gameObject.name = "Opponent";
            clone = 1;
        }
    }

    void Update()
    {

        transform.rotation = cameraRotation.transform.rotation;

        if( ci.result && otherResult)
        {
            StartCoroutine( ShowText() );
        }

    }

    IEnumerator ShowText()
    {

        playersentence = Calculate( ci.choice, otherChoice, guideText);

        yield return new WaitForSeconds(3f);

        guideText.text = "";
        otherResult = false;
        otherChoice = false;

        ci.result = false;
        
    }
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if( stream.IsWriting )
        {

            stream.SendNext( this.gameObject.transform.rotation ); 
            stream.SendNext( ci.choice );
            stream.SendNext( ci.result );
            stream.SendNext( playersentence );
            
        }
        else
        {

            opponentRotation = (Quaternion)stream.ReceiveNext();
            otherChoice = (bool)stream.ReceiveNext();
            otherResult = (bool)stream.ReceiveNext();
            othersentence = (int)stream.ReceiveNext();
            
        }

    }

}
