using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{

    // Esta clase se encarga mover el previsualizado del bloque

    void Update() {
        if (instantiateBlock.instance.buildingUp) {
            Vector3 mouse = Input.mousePosition;
            Ray casepoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(casepoint, out hit, Mathf.Infinity)) {
                transform.position = new Vector3(hit.point.x, hit.point.y + transform.localScale.y / 2, hit.point.z);
                if (hit.collider.gameObject.CompareTag("Arena") || hit.collider.gameObject.CompareTag("Block")) {
                    instantiateBlock.instance.onTheArena = true;
                } else {
                    instantiateBlock.instance.onTheArena = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            transform.Rotate(new Vector3(0,90));
        }
    }
}
