using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
 
 void OnCollisionEnter(Collision col)
 {
    Destroy(gameObject, 2);
 }
}
