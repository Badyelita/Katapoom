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


    void Move()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, target.transform.position, Time.deltaTime);
        player.GetComponent<PlayerMov>().enabled = false;
        
        if (target.transform.position == player.transform.position) {
            canMove = false;
            inGame = true;
        }
        
    }


    void ExitGame()
    {
            player.transform.position = Vector3.MoveTowards(player.transform.position, exit.transform.position, Time.deltaTime);
            
        
        if (player.transform.position == exit.transform.position)
        {
            player.GetComponent<PlayerMov>().enabled = true;
            exitGame = false;
        }
    }
}
