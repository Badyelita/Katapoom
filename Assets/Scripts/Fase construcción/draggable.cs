using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggable : MonoBehaviour
{
    private Vector3 mousePosition;
    private bool dragging = false;
    private Vector3 GetMousePos() {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block") {
            if (dragging) {
                //FIXME no se coloca encima del otro bloque
                gameObject.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 0.1f, collision.transform.position.z);
                Debug.Log(gameObject.transform.position);
            }
        }
    }
}
