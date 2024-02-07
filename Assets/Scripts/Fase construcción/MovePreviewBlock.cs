using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePreviewBlock : MonoBehaviour
{
    void Update() {
        if (SpawnBlock.instance.buildingUp) {
            Vector3 mouse = Input.mousePosition;
            Ray casepoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(casepoint, out hit, Mathf.Infinity)) {
                transform.position = new Vector3(hit.point.x, hit.point.y + transform.localScale.y / 2, hit.point.z);
                if (hit.collider.gameObject.CompareTag("Arena") || hit.collider.gameObject.CompareTag("Block")) {
                    SpawnBlock.instance.onTheArena = true;
                } else {
                    SpawnBlock.instance.onTheArena = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            transform.Rotate(new Vector3(0,90));
        }
    }
}
