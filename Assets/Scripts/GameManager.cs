using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public enum GameState { Ready, Playing, Ended };

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Ready;

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

}
