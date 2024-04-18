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
    [SerializeField] GameObject HudBloques;
    [SerializeField] GameObject HudCartas;
    [SerializeField] TMP_Text textContador;
    [SerializeField] GameObject HudJuego;
    [SerializeField] Button changeFaseButtonToAttack;
    [SerializeField] Button changeFaseButtonToDefense;
    [SerializeField] Button changeFaseButtonToCards;
    [SerializeField] GameObject Joystick1;
    [SerializeField] GameObject Joystick2;
    [SerializeField] Button buttonIzq;
    [SerializeField] Button buttonDer;
    [SerializeField] Button buttonShot;


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
        if(gameState==GameState.Playing && playingState==PlayingState.Defense)
        {
            //Control Android
            Joystick1.gameObject.SetActive(false);
            Joystick2.gameObject.SetActive(false);

            textContador.gameObject.SetActive(true);
            HudBloques.SetActive(true);
            changeFaseButtonToCards.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            HudJuego.SetActive(true);
        }

        if(GameManager.Instance.gameState==GameState.Ready)
        {
            
            changeFaseButtonToCards.gameObject.SetActive(false);
            textContador.gameObject.SetActive(false);
            HudBloques.SetActive(false);
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            HudJuego.SetActive(false);
        }
    }

    public void UpdateGameState(GameState newGameState)
    {
        gameState=newGameState;
    }

    public void UpdatePlayingState(PlayingState newPlayingState)
    {
        playingState=newPlayingState;
    }

        public void ChangeFaseAttack()
    {
        //MIRAR ESTO
        buttonIzq.gameObject.SetActive(true);
        buttonDer.gameObject.SetActive(true);
        buttonShot.gameObject.SetActive(true);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.Instance.UpdatePlayingState(PlayingState.Attack);
        textContador.gameObject.SetActive(false);
        HudCartas.SetActive(false);
        
        changeFaseButtonToDefense.gameObject.SetActive(true);
        changeFaseButtonToAttack.gameObject.SetActive(false);
    }

    public void ChangeFaseCards() {
        GameManager.Instance.UpdatePlayingState(PlayingState.Cards);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        HudCartas.SetActive(true);
        HudBloques.SetActive(false);
        if (buildingUp) {
            Destroy(spawnBlock);
            buildingUp = false;
        }

        changeFaseButtonToAttack.gameObject.SetActive(true);
        changeFaseButtonToCards.gameObject.SetActive(false);

    }

    public void ChangeFaseDefense()
    {
        buttonIzq.gameObject.SetActive(false);
        buttonDer.gameObject.SetActive(false);
        buttonShot.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.Instance.UpdatePlayingState(PlayingState.Defense);
        textContador.gameObject.SetActive(true);
        HudBloques.SetActive(true);

        changeFaseButtonToCards.gameObject.SetActive(true);
        changeFaseButtonToDefense.gameObject.SetActive(false);
    }
}
