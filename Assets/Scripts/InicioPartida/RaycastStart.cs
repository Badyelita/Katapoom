using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    void FixedUpdate()
    {
        //Creamos el Rayo
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward*10, Color.green);
        //Lanzamos el raycast para reconocer la mesa si el personaje la mira
        if (Physics.Raycast(ray, out hit, maxDistance, whatToDetect))
        {
            Debug.DrawRay(ray.origin, ray.direction * 30f, Color.green);
            Debug.Log("Distancia:" + hit.distance);
            Debug.Log("Punto de impacto:" + hit.point);

            if (Input.GetKey(KeyCode.E))
            {
                canMove = true;
                
            }

        } if (canMove)
        {
            Move();
        }

        if (inGame && Input.GetKey(KeyCode.Escape))
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
        }
        
    }

    
    void ExitGame()
    {

        player.transform.position = Vector3.MoveTowards(player.transform.position, exit.transform.position, Time.deltaTime);
            
        
        if (player.transform.position == exit.transform.position)
        {
            player.GetComponent<PlayerMov>().enabled = true;
            exitGame = false;
            GameManager.Instance.UpdateGameState(GameState.Ended);
        }
    }
}
