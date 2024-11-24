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

        //카메라 범위
        yRotation = Mathf.Clamp( yRotation, -60f, 60f );
        xRotation = Mathf.Clamp( xRotation, -30f, 80f );

        //회전
        if ( !CameraInteraction.ClipboardSituation )
        {
            transform.rotation = Quaternion.Slerp( transform.rotation, mouseRotation, Time.deltaTime * 2f );
        }

    }

}
