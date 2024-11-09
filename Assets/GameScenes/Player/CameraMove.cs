using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CameraMove : MonoBehaviourPunCallbacks, IPunObservable
{

    //X와 Y의 대한 감도
    public float sensX;
    public float sensY;

    float xRotation;
    float yRotation;

    //포톤
    public PhotonView pv;
    public Quaternion opponentRotation;

    Transform target;

    void Start()
    {
        
        target = GameObject.Find("headRotation").GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {    

        if(pv.IsMine)
        {
            transform.position = Vector3.Lerp( transform.position, new Vector3(0, 1.34f, -0.959f), 2 * Time.deltaTime );
            
            //마우스방향값 설정
            float mouseX = Input.GetAxisRaw( "Mouse X" ) * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw( "Mouse Y" ) * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;

            Quaternion mouseRotation = Quaternion.Euler( xRotation, yRotation, 0);

            //카메라 범위
            yRotation = Mathf.Clamp( yRotation, -60f, 60f );
            xRotation = Mathf.Clamp( xRotation, -30f, 80f );

            //회전
            if ( !CameraInteraction.ClipboardSituation )
            {
                transform.rotation = Quaternion.Slerp( transform.rotation, mouseRotation, Time.deltaTime * 2f );
            }

        }
        else
        {
            this.gameObject.name = "Opponent";
            this.gameObject.tag = "NetworkObject";
            this.gameObject.SetActive(false);
        }
        
        if( Input.GetKeyDown(KeyCode.Escape) )
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        if( this.gameObject.activeSelf )
        {
            target.rotation = opponentRotation;
        }

    }
    
    //포톤
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
