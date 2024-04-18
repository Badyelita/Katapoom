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
    public GameObject JoystickLook;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        //Obtener el Input del raton

        //Control Android
        float ratonX = JoystickLook.gameObject.GetComponent<FixedJoystick>().Horizontal * Time.deltaTime * sensY;
        float ratonY = JoystickLook.gameObject.GetComponent<FixedJoystick>().Vertical * Time.deltaTime * sensY;

        yRotation += ratonX;
        xRotation -= ratonY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotacion de camara y orientacion
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation=Quaternion.Euler(0,yRotation, 0);
    }
}
