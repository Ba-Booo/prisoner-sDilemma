using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardMove : MonoBehaviour
{

    Vector3 targetPosition;

    public Transform originalPosition;
    public Transform destination;

    bool stop = false;

    public void Restore()
    {
        stop = false;
        transform.position = Vector3.Lerp( transform.position, originalPosition.position, 5 * Time.deltaTime) ;
        transform.rotation = Quaternion.Slerp( transform.rotation, originalPosition.rotation, 5 * Time.deltaTime );
    }

    public void Execution()
    {

        if(stop)
        {
            transform.position = Vector3.Lerp( transform.position, targetPosition, 5 * Time.deltaTime );
            transform.rotation = Quaternion.Slerp( transform.rotation, destination.rotation, 5 * Time.deltaTime );
        }
        else
        {
            targetPosition = destination.position;
            stop = true;
        }
    }

}
