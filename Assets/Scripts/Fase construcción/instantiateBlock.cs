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

    [SerializeField] GameObject block;
    public GameObject spawnBlock;
    public bool buildingUp;
    public bool onTheArena;

    public void InstantiateBlock() {
        if(!buildingUp)
        {
            buildingUp = true;
            spawnBlock = Instantiate(block);
        }
        
    }
}
