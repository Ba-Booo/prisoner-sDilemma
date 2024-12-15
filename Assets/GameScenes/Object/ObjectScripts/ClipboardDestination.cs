using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardDestination : MonoBehaviour
{

    public Transform clipboardPosition;

    void Update()
    {
        transform.position = clipboardPosition.position;
        transform.rotation = clipboardPosition.rotation;
    }
}
