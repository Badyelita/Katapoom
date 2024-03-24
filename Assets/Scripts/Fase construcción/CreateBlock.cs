using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    // Esta clase se encarga del crear el bloque al hacer clic izquierdo y destruir el preview del bloque al hacer click derecho
    
    public GameObject block;

    void Update()
    {
        if (GameManager.Instance.playingState == PlayingState.Defense && GameManager.Instance.gameState == GameState.Playing)
        {

            if (Input.GetMouseButtonDown(0) && GameManager.Instance.buildingUp && GameManager.Instance.onTheArena && HudManager.Instance.countBlocks <= 15)
            {
                Instantiate(block, GameManager.Instance.spawnBlock.transform.position, GameManager.Instance.spawnBlock.transform.rotation);
                /*GameObject block = ObjectPool.instance.GetPooledObject();

                if (block != null) {
                    block.transform.position = GameManager.Instance.spawnBlock.transform.position;
                    block.SetActive(true);

                    HudManager.Instance.countBlocks += 1;
                    HudManager.Instance.UpdateCountBlocks();
                }*/

                HudManager.Instance.countBlocks += 1;
                HudManager.Instance.UpdateCountBlocks();
            }
            if ((Input.GetMouseButtonDown(1) && GameManager.Instance.buildingUp))
            {
                Destroy(GameManager.Instance.spawnBlock);
                GameManager.Instance.buildingUp = false;
            }
        }
    }
}
