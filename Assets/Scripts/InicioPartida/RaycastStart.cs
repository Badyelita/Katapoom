using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
    [SerializeField] Button interact;

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
            //Control Android
            interact.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E) && hit.collider.gameObject.layer == 6)
            {
                canMove = true;
            }
            else if (Input.GetKey(KeyCode.E) && hit.collider.gameObject.layer == 8) {
                HudManager.Instance.isSpeaking = true;
            }
            



        }else
        {
            interact.gameObject.SetActive(false);

        } if (canMove)
        {
            Move();
        }



        

        if (HudManager.Instance.isSpeaking && !inGame)
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

        if(inGame)
        {
            player.GetComponent<PlayerMov>().enabled = false;
        }

    }

    //Metodo para moverse a la silla para empezar la partida
    public void Move()
    {
        //Cambiar esto para que haya transicion de andar hasta la silla
        player.transform.position = target.transform.position;
        
        
        //while(player.GetComponent<Rigidbody>().transform.position!= target.transform.position){
            //Se mueve el jugador a un punto que hemos definido
            //player.GetComponent<Rigidbody>().Move(Vector3.MoveTowards(player.transform.position, target.transform.position, Time.deltaTime), Quaternion.identity);
                //= Vector3.MoveTowards(player.transform.position, target.transform.position, Time.deltaTime);
    //}
        //Hacemos que el jugador no se pueda mover
        player.GetComponent<PlayerMov>().enabled = false;
        Debug.LogWarning("Target " + target.transform.position);
        Debug.LogWarning("Player " + player.transform.position);
        //Si el jugador ha llegado a la posicion designada puede salir de esta dandole al escape
        if (target.transform.position == player.transform.position) {
            Debug.Log(target.transform.position);
            Debug.Log(player.transform.position);
            canMove = false;
            inGame = true;
            interact.gameObject.SetActive(false);
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
            inGame = false;
            GameManager.Instance.UpdateGameState(GameState.Ready);
            GameManager.Instance.UpdatePlayingState(PlayingState.None);
        }
    }
}
