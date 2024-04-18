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

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_EDITOR_LINUX

            if (Input.GetMouseButtonDown(0) && GameManager.Instance.buildingUp && GameManager.Instance.onTheArena && HudManager.Instance.countBlocks <= 15)
            {
                Instantiate(block, GameManager.Instance.spawnBlock.transform.position, GameManager.Instance.spawnBlock.transform.rotation);

                HudManager.Instance.countBlocks += 1;
                HudManager.Instance.UpdateCountBlocks();
            }
            if ((Input.GetMouseButtonDown(1) && GameManager.Instance.buildingUp))
            {
                Destroy(GameManager.Instance.spawnBlock);
                GameManager.Instance.buildingUp = false;
            }
#endif


#if UNITY_ANDROID

            if (GameManager.Instance.buildingUp && GameManager.Instance.onTheArena && HudManager.Instance.countBlocks <= 15)
            {
                Touch touch = Input.GetTouch(0);
                float pressTime = 0;
                if (touch.tapCount == 2 && touch.phase == TouchPhase.Began)
                {
                    Instantiate(block, GameManager.Instance.spawnBlock.transform.position, GameManager.Instance.spawnBlock.transform.rotation);

                    HudManager.Instance.countBlocks += 1;
                    HudManager.Instance.UpdateCountBlocks();
                }

                if (touch.deltaTime > .5f) {
                    Destroy(GameManager.Instance.spawnBlock);
                    GameManager.Instance.buildingUp = false;
                }

            }
#endif
        }
    }    
}
