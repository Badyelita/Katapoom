using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [HideInInspector] public int countBlocks = 0;

    public GameObject block;

    [SerializeField] private TMP_Text textBlocks;
    [SerializeField] private GameObject buttonDoll;

    public bool isSpeaking = false;

    public static HudManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Encontrado más de un HudManager, destruyendo el más nuevo");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void UpdateCountBlocks()
    {
        textBlocks.SetText(String.Format("{0}/16 Bloques", countBlocks));
    }

    public void PressedNormalBlock()
    {
        block.GetComponent<Block>().isHeavy = false;
        block.GetComponent<Block>().isLastChance = false;
        block.GetComponent<Block>().isRandom = false;
        block.GetComponent<Block>().isRebound = false;
        block.GetComponent<Block>().isSlime = false;

    }

    public void PressedHeavyBlock()
    {
        block.GetComponent<Block>().isHeavy = true;
    }
}
