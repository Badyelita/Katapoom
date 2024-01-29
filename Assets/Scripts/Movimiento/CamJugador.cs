using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamJugador : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientacion;

    float yRotacion;
    float xRotacion;

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

        yRotacion += ratonX;
        xRotacion -= ratonY;
    }
}
