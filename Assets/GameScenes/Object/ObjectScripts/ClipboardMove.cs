using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardMove : MonoBehaviour
{

    public Transform originalPosition;
    public Transform destination;

    public void Restore()
    {
        transform.position = Vector3.Lerp( transform.position, originalPosition.position, 5 * Time.deltaTime) ;
        transform.rotation = Quaternion.Slerp( transform.rotation, originalPosition.rotation, 5 * Time.deltaTime );
    }

    public void Execution()
    {
        transform.position = Vector3.Lerp( transform.position, destination.position, 5 * Time.deltaTime );
        transform.rotation = Quaternion.Slerp( transform.rotation, destination.rotation, 5 * Time.deltaTime );
    }
}
