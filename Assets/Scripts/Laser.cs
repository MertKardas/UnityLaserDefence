using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] LaserTypesSO laserType;
    Rigidbody2D rigidbody2;
    public void FireLaser(Vector2 up) {
        rigidbody2 = GetComponent<Rigidbody2D>();
        Vector2 laserVector = up * laserType.velocity; 
        rigidbody2.velocity =  laserVector;
        Destroy(gameObject, laserType.lifeTime);


    }
    
    
}
