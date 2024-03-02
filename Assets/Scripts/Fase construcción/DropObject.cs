using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    // Esta clase se encarga del crear el bloque al hacer clic izquierdo y destruirlo al hacer clic derecho
    public GameObject previewBlock;
    public GameObject block;
    //public GameObject doll;

    void Update() {
        if(GameManager.Instance.playingState == PlayingState.Defense && GameManager.Instance.gameState == GameState.Playing){
            if (Input.GetMouseButtonDown(0) && instantiateBlock.instance.buildingUp && instantiateBlock.instance.onTheArena && HudManager.Instance.countBlocks <= 15) {
                Block blockType = block.GetComponent<Block>();
                //TODO va pero no me gusta la implementacion
                if (blockType.isHeavy)
                {
                    blockType.SetHeavyBlock();
                }
                else if (blockType.isLastChance)
                {

                }
                else if (blockType.isRandom)
                {

                }
                else if (blockType.isRebound)
                {

                }
                else if (blockType.isSlime)
                {

                }
                else 
                {
                    blockType.SetNormalBlock();
                }

                Instantiate(block, instantiateBlock.instance.spawnBlock.transform.position, instantiateBlock.instance.spawnBlock.transform.rotation);
                HudManager.Instance.countBlocks += 1;
                HudManager.Instance.UpdateCountBlocks();
            }
            if ((Input.GetMouseButtonDown(1) && instantiateBlock.instance.buildingUp)) {
                Destroy(instantiateBlock.instance.spawnBlock);
                instantiateBlock.instance.buildingUp = false;
            }
        }
    }
}
