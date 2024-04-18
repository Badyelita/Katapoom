using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRight : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{

    public bool pressed=false;
    public GameObject katapult;
    [SerializeField] float rotationSpeed=0.3f;

    void FixedUpdate()
    {
        if(pressed && katapult.gameObject.transform.rotation.eulerAngles.y<355f)
        {
            katapult.gameObject.transform.Rotate(0f, rotationSpeed, 0f, Space.Self);
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
