using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLeft : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{

    public bool pressed=false;
    public GameObject katapult;
    [SerializeField] float rotationSpeed=0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pressed && katapult.gameObject.transform.rotation.eulerAngles.y>180f)
        {
            katapult.gameObject.transform.Rotate(0f, -rotationSpeed, 0f, Space.Self);
        }
    }

    public void OnPointerDown (PointerEventData eventData)
    {
        pressed=true;
    }

        public void OnPointerUp(PointerEventData eventData)
    {
        pressed=false;
    }
}
