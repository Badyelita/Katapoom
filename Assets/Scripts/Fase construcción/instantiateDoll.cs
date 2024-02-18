using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateDoll : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject block;
    [HideInInspector] public GameObject spawnBlock;

    public void InstantiateBlock()
    {
        if (!instantiateBlock.instance.buildingUp)
        {
            instantiateBlock.instance.buildingUp = true;
            spawnBlock = Instantiate(block);
        }
    }
}
