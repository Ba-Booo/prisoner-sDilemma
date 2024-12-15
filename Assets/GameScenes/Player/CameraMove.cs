using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    //X와 Y의 대한 감도
    public float sensX;
    public float sensY;

    float xRotation;
    float yRotation;

    //상호작용시 기준점
    bool standardStore = true;
    Vector3 rotationStandard;
    public Transform standard;

    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {    

        transform.position = Vector3.Lerp( transform.position, new Vector3(0, 1.34f, -0.959f), 2 * Time.deltaTime );
            
        //마우스방향값 설정
        float mouseX = Input.GetAxisRaw( "Mouse X" ) * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw( "Mouse Y" ) * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        Quaternion mouseRotation = Quaternion.Euler( xRotation, yRotation, 0);

        transform.rotation = Quaternion.Slerp( transform.rotation, mouseRotation, Time.deltaTime * 2f );



        //회전
        if ( CameraInteraction.ClipboardSituation && standardStore)
        {
            
            rotationStandard = standard.eulerAngles;
            standardStore = false;

        }
        else if ( CameraInteraction.ClipboardSituation && !standardStore)
        {

            yRotation = Mathf.Clamp( yRotation, rotationStandard.y + 165f, rotationStandard.y + 195f );//좌우
            xRotation = Mathf.Clamp( xRotation, rotationStandard.x -60f, rotationStandard.x );

        }
        else
        {

            yRotation = Mathf.Clamp( yRotation, -60f, 60f );
            xRotation = Mathf.Clamp( xRotation, -30f, 80f );
            standardStore = true;

        }

    }

}
