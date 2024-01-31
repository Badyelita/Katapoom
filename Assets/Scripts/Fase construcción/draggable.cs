using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggable : MonoBehaviour
{
    private Vector3 mousePosition;
    //FIXME al chocar un bloque con otro las fisicas se vuelven locas.
    [SerializeField] private float downForce;
    private bool isDraggable = true;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private Vector3 GetMousePos() {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown() {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag() {
        if (isDraggable) {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
            transform.position += new Vector3(0f, 0.2f, 0f);
        }
    }

    private void OnMouseUp()
    {
        rb.AddForce(new Vector3(0f, downForce));
        
    }

    private void OnCollisionEnter(Collision collision) {
        rb.velocity = new Vector3(0, 0, 0);

        if (collision.gameObject.tag.Equals("Floor")) {
            Destroy(gameObject);
        }
        if (transform.position.y < collision.gameObject.transform.position.y) { 
            isDraggable = false;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (transform.position.y < collision.gameObject.transform.position.y) {
            isDraggable = true;
        }
    }
}
