using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GameState { Ready, Playing, Paused, Ended };

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Ready;
    public int countBlocks = 0;
    public GameObject block;
    public static GameManager Instance { get; private set; }
    

    
    void Awake()
    {
    if (Instance !=null)
        {
            Debug.Log("Encontrado más de un GameManager, destruyendo el más nuevo");
            Destroy(this.gameObject);
            return;
        }
        Instance=this;

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 

    }

    public void UpdateGameState(GameState newGameState)
    {
        gameState=newGameState;

        switch (gameState)
        {
            case GameState.Ready:
            HandleChangePovFirstPerson();
            break;

            case GameState.Playing:
            HandleChangePovZenithal();
            break;

            case GameState.Ended:
            break;

            case GameState.Paused:
            break;
            
            default:
            throw new ArgumentOutOfRangeException(nameof(newGameState), newGameState, null);
        }
    }

    void HandleChangePovZenithal()
    {
        
    }

    void HandleChangePovFirstPerson()
    {
        
    }

    public void UpdateHud() {
        GameObject.FindGameObjectWithTag("countBlock").GetComponent<TMP_Text>().SetText(String.Format("{0}/16 Bloques", countBlocks));
    }

    public void PressedNormalBlock() {
        block.GetComponent<Block>().isHeavy = false;
        block.GetComponent<Block>().isLastChance = false;
        block.GetComponent<Block>().isRandom = false;
        block.GetComponent<Block>().isRebound = false;
        block.GetComponent<Block>().isSlime = false;
    }

    public void PressedHeavyBlock() {
        block.GetComponent<Block>().isHeavy = true;
    }
}
