using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Vector3 offset;

    public Transform target;

    private void LateUpdate()
    {
        if(target)
        {
            transform.position = target.position + offset;
        }        
    }
}
