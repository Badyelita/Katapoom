using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAndDestroyPreviewBlock : MonoBehaviour
{
    public GameObject previewBlock;
    public GameObject block;

    void Update() {
        if (Input.GetMouseButtonDown(0) && SpawnBlock.instance.buildingUp && SpawnBlock.instance.onTheArena) {
            Instantiate(block, SpawnBlock.instance.spawnBlock.transform.position, SpawnBlock.instance.spawnBlock.transform.rotation);
        }
        if (Input.GetMouseButtonDown(1) && SpawnBlock.instance.buildingUp) {
            Destroy(SpawnBlock.instance.spawnBlock);
            SpawnBlock.instance.buildingUp = false;
        }
    }
}
