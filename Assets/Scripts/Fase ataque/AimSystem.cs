using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AimSystem : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] float rotationSpeed=0.3f;
    public float BlastPower = 5;

    public float force;
    bool min;
    bool pressed=false;
    bool soltado;
    public GameObject Projectile;
    public Transform ShootPoint;
    [SerializeField] private GameObject PauseManager;
    

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

        if(pressed && GameManager.Instance.playingState == PlayingState.Attack && GameManager.Instance.gameState == GameState.Playing){
            PauseManager.GetComponent<PauseManager>().enabled = false;
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
        
        if(soltado && GameManager.Instance.playingState == PlayingState.Attack && GameManager.Instance.gameState == GameState.Playing)
        {
            Shooting(force);
            soltado=false;
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

//NO SE QUE PASA VOY A NECESITAR OTRO SCRIPT DONDE CONTROLAR SI ESTA PRESIONADO Y SI ESTA PRESIONADO GIRAR LA KATAPULTA EN EL UPDATE


    
    public void Shooting(float forceShoot)
    {
        GameObject CreatedProjectile = Instantiate(Projectile, ShootPoint.position, ShootPoint.rotation);
        CreatedProjectile.GetComponent<Rigidbody>().velocity = ShootPoint.transform.up * forceShoot;
        force=3f;
        PauseManager.GetComponent<PauseManager>().enabled = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed=true;
        soltado=false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed=false;
        soltado=true;
        
    }
}
