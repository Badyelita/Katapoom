using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;

    public float groundDrag;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 movementDir;

    public GameObject Joystick;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
        SpeedControl();
        rb.drag = groundDrag;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        //Control Android
        horizontalInput = Joystick.gameObject.GetComponent<FixedJoystick>().Horizontal;
        verticalInput = Joystick.gameObject.GetComponent<FixedJoystick>().Vertical;

        Debug.Log(horizontalInput);
    }

    private void MovePlayer()
    {
        //Calculamos la direccion del movimiento
        movementDir=orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(movementDir.normalized * movementSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel=new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude>movementSpeed)
        {
            Vector3 velocidadLimit=flatVel.normalized*movementSpeed;
            rb.velocity = new Vector3(velocidadLimit.x, rb.velocity.y, velocidadLimit.z);
        }
    }


}
