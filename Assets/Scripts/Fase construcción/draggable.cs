using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] private BoxCollider bc;
    [SerializeField] private Rigidbody rb;
    RaycastHit hit;
    Ray casepoint;
    [SerializeField] private LayerMask whatToDetect;
    [SerializeField] private bool isDoll;

    private bool canMove;
    private void OnMouseOver()
    {
        if (GameManager.Instance.playingState == PlayingState.Defense && !GameManager.Instance.buildingUp && Input.GetMouseButtonDown(1) && canMove && !isDoll)
        {
            Destroy(gameObject);
            HudManager.Instance.countBlocks -= 1;
            HudManager.Instance.UpdateCountBlocks();
        }
    }

    private void OnMouseDrag()
    {
        if (!GameManager.Instance.buildingUp && GameManager.Instance.playingState == PlayingState.Defense)
        {
            Vector3 mouse = Input.mousePosition;
            Ray casepoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;

            if (Physics.Raycast(casepoint, out hit, Mathf.Infinity) && (hit.collider.gameObject.CompareTag("Arena") || hit.collider.gameObject.CompareTag("Block")) && canMove)
            {

                bc.enabled = false;
                rb.isKinematic = true;

                if (isDoll)
                {
                    rb.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                }
                else {
                    rb.position = new Vector3(hit.point.x, hit.point.y + transform.localScale.y / 2, hit.point.z);
                    if (Input.GetKeyDown(KeyCode.R)) {
                        rb.transform.Rotate(new Vector3(0, 90));
                    }
                }
            }
        }
    }

    private void OnMouseUp()
    {
        bc.enabled = true;
        rb.isKinematic = false;
    }

    private void Update()
    {
        casepoint = new Ray(transform.position, transform.up);
        if (Physics.Raycast(casepoint, out hit, gameObject.transform.localScale.y, whatToDetect)) {
            canMove = false;
        }
        else {
            canMove = true;
        }
    }
}
