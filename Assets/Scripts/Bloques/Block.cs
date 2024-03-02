using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] public Rigidbody rb;

    [SerializeField] public bool isSlime, isHeavy, isRebound, isLastChance, isRandom;

    public void SetNormalBlock()
    {
        rb.mass = 1f;
    }
    public void SetSlimeBlock() {
    }

    public void SetHeavyBlock() {
        rb.mass = 2f;
    }

    public void SetReboundBlock()
    {
    }

    public void SetLastChanceBlock()
    {
    }

    public void SetRandomBlock()
    {
    }
}
