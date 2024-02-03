using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    // Esta clase se encarga del crear el bloque al hacer clic izquierdo y destruirlo al hacer clic derecho
    public GameObject previewBlock;
    public GameObject block;

    void Update() {
        if (Input.GetMouseButtonDown(0) && instantiateBlock.instance.buildingUp && instantiateBlock.instance.onTheArena) {
            Instantiate(block, instantiateBlock.instance.spawnBlock.transform.position, instantiateBlock.instance.spawnBlock.transform.rotation);
        }
        if (Input.GetMouseButtonDown(1) && instantiateBlock.instance.buildingUp) {
            Destroy(instantiateBlock.instance.spawnBlock);
            instantiateBlock.instance.buildingUp = false;
        }
    }
}
