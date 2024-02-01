using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;
    RaycastStart raycastStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Change();
      
    }

    void Change()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            cam1.GetComponent<CinemachineVirtualCamera>().enabled=false;
            cam2.GetComponent<CinemachineVirtualCamera>().enabled = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            cam1.GetComponent<CinemachineVirtualCamera>().enabled = true;
            cam2.GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
    }
}
