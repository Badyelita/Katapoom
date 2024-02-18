using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    // Esta clase se encarga del crear el bloque al hacer clic izquierdo y destruirlo al hacer clic derecho
    public GameObject previewBlock;
    public GameObject block;
    public GameObject doll;

    void Update() {
    if(GameManager.Instance.gameState==GameState.Playing){
        if (Input.GetMouseButtonDown(0) && instantiateBlock.instance.buildingUp && instantiateBlock.instance.onTheArena && GameManager.Instance.countBlocks <= 15) {
                //TODO va pero no me gusta la implementacion
            if (block.GetComponent<Block>().isHeavy)
            {
                block.GetComponent<Block>().mass = 2f;
            }
            else if (block.GetComponent<Block>().isLastChance)
            {

            }
            else if (block.GetComponent<Block>().isRandom)
            {

            }
            else if (block.GetComponent<Block>().isRebound)
            {

            }
            else if (block.GetComponent<Block>().isSlime)
            {

            }
            else 
            {
                block.GetComponent<Block>().mass = 1f;
            }

            if (GameManager.Instance.isDoll) {
                Instantiate(doll, instantiateBlock.instance.spawnBlock.transform.position, instantiateBlock.instance.spawnBlock.transform.rotation);
            } else {
                Instantiate(block, instantiateBlock.instance.spawnBlock.transform.position, instantiateBlock.instance.spawnBlock.transform.rotation);
                GameManager.Instance.countBlocks += 1;
                GameManager.Instance.UpdateHud();
            }
        }
        if (Input.GetMouseButtonDown(1) && instantiateBlock.instance.buildingUp) {
            Destroy(instantiateBlock.instance.spawnBlock);
            instantiateBlock.instance.buildingUp = false;
        }
    }
    }
}
