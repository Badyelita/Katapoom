using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Transform posicionCamara;

    // Update is called once per frame
    void Update()
    {
        transform.position = posicionCamara.position;
    }
}