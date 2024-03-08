using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPreview : MonoBehaviour
{
    //Esta clase se encarga de spawnear el bloque

    [SerializeField] private GameObject previewBlock;
    [SerializeField] private Block scriptBlock;

    private void Update()
    {

        // En este update la estructura mas logica para controlar que tecla pulsa el usuario es un switch, no un if
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            InstantiateBlock(previewBlock);
            scriptBlock.SetNormalBlock();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            InstantiateBlock(previewBlock);
            scriptBlock.SetHeavyBlock();
        }
    }

    public void InstantiateBlock(GameObject block)
    {
        if (!GameManager.Instance.buildingUp)
        {
            GameManager.Instance.buildingUp = true;
            GameManager.Instance.spawnBlock = Instantiate(block);
        }
    }
}
