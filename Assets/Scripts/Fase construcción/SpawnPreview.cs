using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPreview : MonoBehaviour
{
    //Esta clase se encarga de spawnear el bloque

    

    public void InstantiateBlock(GameObject block)
    {
        if (!GameManager.Instance.buildingUp)
        {
            GameManager.Instance.buildingUp = true;
            GameManager.Instance.spawnBlock = Instantiate(block);
        }
    }
}
