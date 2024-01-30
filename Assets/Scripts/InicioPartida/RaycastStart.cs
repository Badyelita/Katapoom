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
    bool startGame = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    void Update()
    {

        Ray ray = new Ray(transform.position, transform.forward);


        if (Physics.Raycast(ray, out hit, maxDistance, whatToDetect))
        {
            Debug.DrawRay(ray.origin, ray.direction * 30f, Color.green);
            Debug.Log("Distancia:" + hit.distance);
            Debug.Log("Punto de impacto:" + hit.point);

            if (Input.GetKey(KeyCode.E))
            {
                startGame = true;
            }

        } if (startGame)
        {
            Move();
        }


    }


    void Move()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, target.transform.position, Time.deltaTime);

        
        if(target.transform.position == player.transform.position) {
            startGame = false;
        }
        
    }
}
