using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggable : MonoBehaviour
{
    //private bool isDraggable = true;
    //estoy modificando el valor del eje x e y del prefab, no del objeto en si

    void Update()
    {
        float yInput = Input.GetAxis("Mouse Y");
        float xInput = Input.GetAxis("Mouse X");

        Debug.Log("Eje x: " + yInput);
        Debug.Log("Eje y: " + xInput);

        Vector3 mousePos = new Vector3(xInput,yInput);

        transform.position = mousePos;

    }
}
