using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateBlock : MonoBehaviour
{

    [SerializeField] GameObject block;
    
    private Vector3 vector = new(2f, 1.1f, 1f);

    public void InstantiateBlock() {
        Instantiate(block, vector, Quaternion.identity);
    }
}
