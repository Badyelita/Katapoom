using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float yRotation;
    float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Obtener el Input del raton
        float ratonX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float ratonY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += ratonX;
        xRotation -= ratonY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotacion de camara y orientacion
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation=Quaternion.Euler(0,yRotation, 0);
    }
}
