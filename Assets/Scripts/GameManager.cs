using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GameState { Ready, Playing, Paused, Ended };
public enum PlayingState { None, Defense, Cards, Attack};

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Ready;
    public PlayingState playingState = PlayingState.None;

    [HideInInspector] public GameObject spawnBlock;
    [HideInInspector] public bool buildingUp;
    [HideInInspector] public bool onTheArena;

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
    }

    public void UpdatePlayingState(PlayingState newPlayingState)
    {
        playingState=newPlayingState;
    }
}
