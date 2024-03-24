using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour, IDraggable
{
    [SerializeField] public Rigidbody rb;
    private bool canMove;

    RaycastHit hit;
    Ray casepoint;
    [SerializeField] private LayerMask blockLayer;

    public void SetNormalBlock() {
        rb.mass = 1f;
    }
    public void SetSlimeBlock() {
    }

    public void SetHeavyBlock() {
        rb.mass = 2f;
    }

    public void SetReboundBlock() {
    }
        
    public void SetLastChanceBlock() {
    }

    public void SetRandomBlock() {
    }

    private void OnMouseOver()
    {
        if (GameManager.Instance.playingState == PlayingState.Defense && !GameManager.Instance.buildingUp && Input.GetMouseButtonDown(1) && canMove)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);

            HudManager.Instance.countBlocks -= 1;
            HudManager.Instance.UpdateCountBlocks();
        }
    }

    private void OnMouseDrag()
    {
        if (!GameManager.Instance.buildingUp && GameManager.Instance.playingState == PlayingState.Defense)
        {
            dragGO();
            RotateBlock();
        }
    }

    private void OnMouseUp()
    {
        gameObject.layer = LayerMask.NameToLayer("Block");
    }

    private void Update()
    {
        casepoint = new Ray(transform.position, transform.up);
        if (Physics.Raycast(casepoint, out hit, gameObject.transform.localScale.y, blockLayer))
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }

    public void dragGO()
    {
        Vector3 mouse = Input.mousePosition;
        Ray casepoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;

        if (Physics.Raycast(casepoint, out hit, Mathf.Infinity) && canMove)
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

            if (hit.collider.gameObject.CompareTag("Arena"))
            {
                transform.position = new Vector3(hit.point.x, hit.point.y + transform.localScale.y / 2, hit.point.z);
            }

            else if (hit.collider.gameObject.CompareTag("Block"))
            {
                transform.position = new Vector3(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y + transform.localScale.y, hit.collider.gameObject.transform.position.z);
            }
        }
        
    }

    private void RotateBlock()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(new Vector3(0, 90));
        }
    }
}
