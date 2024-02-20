using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    private float rotationX;
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
    }


    void AimingKatapult()
    {
        if(Input.GetKey(KeyCode.A) && transform.rotation.eulerAngles.y>180f)
        {
            gameObject.transform.Rotate(0f, -rotation, 0f, Space.Self);
        }
        if(Input.GetKey(KeyCode.D) && transform.rotation.eulerAngles.y<355f)
        {
            gameObject.transform.Rotate(0f, rotation, 0f, Space.Self);
        }
    }
}
