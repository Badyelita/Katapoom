using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPreview : MonoBehaviour
{
    //Esta clase se encarga de spawnear el preview del bloque

    [SerializeField] private GameObject previewBlock;
    [SerializeField] private Block scriptBlock;

    private void Update()
    {

        
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
