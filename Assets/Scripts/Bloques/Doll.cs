using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Doll : MonoBehaviour, IDraggable
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private LayerMask layers;
    private bool isDragging = false;
    private bool canMove = true;

    RaycastHit hit;

    private void OnMouseDrag()
    {
        DragGO();
    }

    private void OnMouseUp()
    {
        isDragging = false;
        rb.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDragging && collision.gameObject.CompareTag("Doll"))
        {
            canMove = false;
        }
    }

    public void DragGO()
    {
        if (!GameManager.Instance.buildingUp && GameManager.Instance.playingState == PlayingState.Defense)
        {

            Vector3 mouse = Input.mousePosition;
            Ray casepoint = Camera.main.ScreenPointToRay(mouse);
            rb.isKinematic = false;
            
            isDragging = true;
            if (Physics.Raycast(casepoint, out hit, Mathf.Infinity, layers) && canMove)
            {
                transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

            }

            if (!canMove) {
                Physics.Raycast(casepoint, out hit, Mathf.Infinity);
                
                if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Arena")) {
                    canMove = true;
                }
            }
        }
    }
}
