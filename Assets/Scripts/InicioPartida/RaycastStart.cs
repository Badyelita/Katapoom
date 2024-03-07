using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaycastStart : MonoBehaviour
{

    [SerializeField] private LayerMask[] whatToDetect;
    float maxDistance = 3f;
    RaycastHit hit;
    public GameObject player;
    public GameObject target;
    public GameObject exit;
    bool canMove = false;
    public bool inGame = false;
    public bool exitGame = false;
    

    [SerializeField] GameObject block;
    [SerializeField] TMP_Text text;
    [SerializeField] Button changeFaseButton;
    [SerializeField] GameObject dialogPanel;

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
        if (Physics.Raycast(ray, out hit, maxDistance, whatToDetect[0]) || Physics.Raycast(ray, out hit, maxDistance, whatToDetect[1]))
        {
            if (Input.GetKey(KeyCode.E) && hit.collider.gameObject.layer == 6)
            {
                canMove = true;
            }
            else if (Input.GetKey(KeyCode.E) && hit.collider.gameObject.layer == 8) {
                HudManager.Instance.isSpeaking = true;
            }



        } if (canMove)
        {
            Move();
        }

        if (HudManager.Instance.isSpeaking)
        {
            dialogPanel.SetActive(true);
            dialogPanel.GetComponent<DialogoScript>().enabled = true;
            player.GetComponent<PlayerMov>().enabled = false;
        }
        else {
            dialogPanel.SetActive(false);
            dialogPanel.GetComponent<DialogoScript>().enabled = false;
            player.GetComponent<PlayerMov>().enabled = true;
        }

        if (GameManager.Instance.playingState == PlayingState.Defense && Input.GetKey(KeyCode.Backspace))
        {
            exitGame = true; 
           
        }
        if (exitGame)
        {
            ExitGame();
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
            GameManager.Instance.UpdatePlayingState(PlayingState.Defense);
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
            GameManager.Instance.UpdatePlayingState(PlayingState.None);
        }
    }
}
