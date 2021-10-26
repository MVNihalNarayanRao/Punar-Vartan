using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool kindaSusLevel;

    private void Start()
    {
        if(kindaSusLevel)
        {
            GetComponent<Collider>().enabled = false;
        }
    }
}
