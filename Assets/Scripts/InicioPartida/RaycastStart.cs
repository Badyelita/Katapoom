using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaycastStart : MonoBehaviour
{

    [SerializeField] private LayerMask whatToDetect;
    float maxDistance = 3f;
    RaycastHit hit;
    public GameObject player;
    public GameObject target;
    public GameObject exit;
    bool canMove = false;
    public bool inGame = false;
    public bool exitGame = false;

    [SerializeField] Button block;
    [SerializeField] TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    void FixedUpdate()
    {
        //Creamos el Rayo
        Ray ray = new Ray(transform.position, transform.forward);
        //Lanzamos el raycast para reconocer la mesa si el personaje la mira
        if (Physics.Raycast(ray, out hit, maxDistance, whatToDetect))
        {
            if (Input.GetKey(KeyCode.E))
            {
                canMove = true;
                
            }

        } if (canMove)
        {
            Move();
        }

        if (inGame && Input.GetKey(KeyCode.Backspace))
        {
            exitGame = true; 
           
        }
        if (exitGame)
        {
            ExitGame();
        }

        if(GameManager.Instance.gameState==GameState.Playing)
        {
            //TODO: Cambiarlo al GameManager
            text.gameObject.SetActive(true);
            block.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if(GameManager.Instance.gameState==GameState.Ready)
        {
            //TODO: Cambiarlo al GameManager
            text.gameObject.SetActive(false);
            block.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        //TODO: MEJORAR

        if(GameManager.Instance.gameState==GameState.Playing && Input.GetKey(KeyCode.Space))
        {
            GameManager.Instance.UpdatePlayingState(PlayingState.Attack);
            text.gameObject.SetActive(false);
            block.gameObject.SetActive(false);

        }

        


    }

    //Metodo para moverse a la silla para empezar la partida
    void Move()
    {
        //Se mueve el jugador a un punto que hemos definido
        player.transform.position = Vector3.MoveTowards(player.transform.position, target.transform.position, Time.deltaTime);
        //Hacemos que el jugador no se pueda mover
        player.GetComponent<PlayerMov>().enabled = false;
        //Si el jugador ha llegado a la posicion designada puede salir de esta dandole al escape
        if (target.transform.position == player.transform.position) {
            canMove = false;
            inGame = true;
            //Se actualiza el estado del juego
            GameManager.Instance.UpdateGameState(GameState.Playing);
        }
        
    }

    
    void ExitGame()
    {

        player.transform.position = Vector3.MoveTowards(player.transform.position, exit.transform.position, Time.deltaTime);
            
        
        if (player.transform.position == exit.transform.position)
        {
            player.GetComponent<PlayerMov>().enabled = true;
            exitGame = false;
            GameManager.Instance.UpdateGameState(GameState.Ready);
        }
    }
}
