using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Doll : MonoBehaviour, IDraggable
{

    private void OnMouseDrag()
    {
        dragGO();
    }

    public void dragGO()
    {
        if (!GameManager.Instance.buildingUp && GameManager.Instance.playingState == PlayingState.Defense)
        {

            Vector3 mouse = Input.mousePosition;
            Ray casepoint = Camera.main.ScreenPointToRay(mouse);

            if (Physics.Raycast(casepoint, out RaycastHit hit, Mathf.Infinity) && (hit.collider.gameObject.CompareTag("Arena") || hit.collider.gameObject.CompareTag("Block")))
            {
                transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
        }
    }
}
