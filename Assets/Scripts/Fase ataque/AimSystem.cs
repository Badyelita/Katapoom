using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    [SerializeField] float rotationSpeed=0.3f;
    public float BlastPower = 5;

    public float force;
    bool min;

    public GameObject Projectile;
    public Transform ShootPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if(GameManager.Instance.playingState==PlayingState.Attack )
        {
            AimingKatapult();
        }
        if(Input.GetKey(KeyCode.Space)){
            if(min)
            {
                force+=0.05f;
                if(force>=7f)
                {
                    min=false;
                }
            }
            if(!min)
            {
                force-=0.05f;
                if(force<=3f)
                {
                    min=true;
                }
            }
            
        }

    }
    void Update()
    {
        
        if(Input.GetKeyUp(KeyCode.Space) && GameManager.Instance.playingState == PlayingState.Attack && GameManager.Instance.gameState == GameState.Playing)
        {
            Shooting(force);
        }
    }


    void AimingKatapult()
    {
        if(Input.GetKey(KeyCode.A) && transform.rotation.eulerAngles.y>180f)
        {
            transform.Rotate(0f, -rotationSpeed, 0f, Space.Self);
        }
        if(Input.GetKey(KeyCode.D) && transform.rotation.eulerAngles.y<355f)
        {
            transform.Rotate(0f, rotationSpeed, 0f, Space.Self);
        }
    }

    //Transformar lo del if en un metodo
    void Shooting(float forceShoot)
    {
        GameObject CreatedProjectile = Instantiate(Projectile, ShootPoint.position, ShootPoint.rotation);
        CreatedProjectile.GetComponent<Rigidbody>().velocity = ShootPoint.transform.up * forceShoot;
        force=3f;
    }
}
