using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadMovimiento;

    public float groundDrag;

    public Transform orientacion;

    float horizontalInput;
    float verticalInput;

    Vector3 direccionMov;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MiInput();
        ControlVelocidad();
        rb.drag = groundDrag;
    }

    private void FixedUpdate()
    {
        MoverJugador();
    }

    private void MiInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MoverJugador()
    {
        //Calculamos la direccion del movimiento
        direccionMov=orientacion.forward * verticalInput + orientacion.right * horizontalInput;

        rb.AddForce(direccionMov.normalized * velocidadMovimiento * 10f, ForceMode.Force);
    }

    private void ControlVelocidad()
    {
        Vector3 flatVel=new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude>velocidadMovimiento)
        {
            Vector3 velocidadLimit=flatVel.normalized*velocidadMovimiento;
            rb.velocity = new Vector3(velocidadLimit.x, rb.velocity.y, velocidadLimit.z);
        }
    }


}
