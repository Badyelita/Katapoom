using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public static SpawnBlock instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    [SerializeField] GameObject block;
    public GameObject spawnBlock;
    public bool buildingUp;
    public bool onTheArena;

    public void InstantiateBlock()
    {
        buildingUp = true;
        spawnBlock = Instantiate(block);
    }
}
