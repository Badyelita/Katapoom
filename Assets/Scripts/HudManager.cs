using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [HideInInspector] public int countBlocks = 0;
    [HideInInspector] public int countDoll = 0;
    public GameObject block;

    [HideInInspector] public bool isDoll = false;

    [SerializeField] private TMP_Text textBlocks;
    [SerializeField] private GameObject buttonDoll;

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

    public void UpdateCountDolls()
    {
        if (countDoll == 4)
        {
            buttonDoll.SetActive(false);

            //TODO estas 2 lineas ya estan en el DropObject, hay que crear un script aparte (CommonMethods) y ahi declarar la funcion para usarla desde ahi
            Destroy(instantiateBlock.instance.spawnBlock);
            instantiateBlock.instance.buildingUp = false;
        }
        else {
            buttonDoll.SetActive(true);
        }
    }

    public void PressedNormalBlock()
    {
        block.GetComponent<Block>().isHeavy = false;
        block.GetComponent<Block>().isLastChance = false;
        block.GetComponent<Block>().isRandom = false;
        block.GetComponent<Block>().isRebound = false;
        block.GetComponent<Block>().isSlime = false;

        isDoll = false;
    }

    public void PressedHeavyBlock()
    {
        block.GetComponent<Block>().isHeavy = true;
        isDoll = false;
    }

    public void PressedDollButton()
    {
        isDoll = true;
    }
}
