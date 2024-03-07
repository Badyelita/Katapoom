using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] public Rigidbody rb;

    public void SetNormalBlock() {
        rb.mass = 1f;
    }
    public void SetSlimeBlock() {
    }

    public void SetHeavyBlock() {
        rb.mass = 2f;
    }

    public void SetReboundBlock() {
    }
        
    public void SetLastChanceBlock() {
    }

    public void SetRandomBlock() {
    }
}
