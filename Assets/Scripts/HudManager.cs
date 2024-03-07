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

    public bool isSpeaking = false;

    public static HudManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Encontrado m�s de un HudManager, destruyendo el m�s nuevo");
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
}
