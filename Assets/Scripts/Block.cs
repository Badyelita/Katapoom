using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public float mass;

    [SerializeField] public bool isSlime, isHeavy, isRebound, isLastChance, isRandom;

    public void SetNormalBlock()
    {
        mass = 1f;
    }
    public void SetSlimeBlock() {
    }

    public void SetHeavyBlock() {
        mass = 2f;
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
