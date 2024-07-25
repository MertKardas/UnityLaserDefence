using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    //[SerializeField] float hp = 100f;
    [SerializeField] LayerMask targetLayer; 
    
    Collider2D collider2d;
    private void Start() {
        collider2d = GetComponent<Collider2D>();
       

    }
    private void OnTriggerEnter2D(Collider2D collision) {
        int collisionLayer = collision.gameObject.layer;
       

        // Check if the collision object is on one of the target layers
        if ((targetLayer & (1 << collisionLayer)) != 0) {
           
            Destroy(gameObject);
        }
    }
}
