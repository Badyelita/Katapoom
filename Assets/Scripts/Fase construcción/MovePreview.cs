using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePreview : MonoBehaviour
{

    [SerializeField] private LayerMask layers;
    private bool canMove = true;

    void Update()
    {

        if (GameManager.Instance.buildingUp)
        {
            Vector3 mouse = Input.mousePosition;
            Ray casepoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(casepoint, out hit, Mathf.Infinity, layers) && canMove)
            {

                if (hit.collider.gameObject.CompareTag("Arena"))
                {
                    transform.position = new Vector3(hit.point.x, hit.point.y + transform.localScale.y / 2, hit.point.z);
                    GameManager.Instance.onTheArena = true;
                } 
                else if (hit.collider.gameObject.CompareTag("Block")) 
                {
                    transform.position = new Vector3(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y + transform.localScale.y, hit.collider.gameObject.transform.position.z);
                    GameManager.Instance.onTheArena = true;
                }
                else
                {
                    GameManager.Instance.onTheArena = false;
                }
            }

            if (!canMove)
            {
                Physics.Raycast(casepoint, out hit, Mathf.Infinity);

                if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Arena"))
                {
                    canMove = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(new Vector3(0, 90));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Doll"))
        {
            canMove = false;
        }
    }
}
