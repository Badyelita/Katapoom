using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggable : MonoBehaviour {
    [SerializeField] private BoxCollider bc;
    RaycastHit hit;
    Ray casepoint;

    private bool canMove;

    private void OnMouseOver() {
        if (!instantiateBlock.instance.buildingUp && Input.GetMouseButtonDown(1) && canMove) {
            Destroy(gameObject);
        }
    }

    private void OnMouseDrag() {
        if (!instantiateBlock.instance.buildingUp) {
            bc.enabled = false;
            Vector3 mouse = Input.mousePosition;
            Ray casepoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;

            if (Physics.Raycast(casepoint, out hit, Mathf.Infinity) && (hit.collider.gameObject.CompareTag("Arena") || hit.collider.gameObject.CompareTag("Block")) && canMove) {
                transform.position = new Vector3(hit.point.x, hit.point.y + transform.localScale.y / 2, hit.point.z);
            }
        }
    }

    private void OnMouseUp() {
        bc.enabled = true;
    }

    private void Update() {
        casepoint = new Ray(transform.position, transform.up);
        if (Physics.Raycast(casepoint, out hit, Mathf.Infinity)) {
            canMove = false;
        }
        else {
            canMove = true;
        }
    }
}
