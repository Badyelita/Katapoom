using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    [SerializeField] float rotation=0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.playingState==PlayingState.Attack)
        {
            AimingKatapult();
        }
         //gameObject.transform.Rotate(0f, 5f, 0f, Space.Self);
    }


    void AimingKatapult()
    {
        if(Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(0f, rotation, 0f, Space.Self);
        }
        if(Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(0f, -rotation, 0f, Space.Self);
        }
    }
}