using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateBlock : MonoBehaviour
{
    public static instantiateBlock instance { get; private set; }

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
        } else { 
            instance = this;
        }
    }

    //Esta clase se encarga de spawnear el bloque

    [HideInInspector] public GameObject spawnBlock;
    [HideInInspector] public bool buildingUp;
    [HideInInspector] public bool onTheArena;

    public void InstantiateBlock(GameObject block) {
        if(!buildingUp)
        {
            buildingUp = true;
            spawnBlock = Instantiate(block);
        }
    }
}
