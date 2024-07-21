using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    Vector2 moveVector;
    Vector2 minBound;
    Vector2 maxBound;
    
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float padding = 0.5f; 
    // Start is called before the first frame update
    void Start() {
        Camera camera = Camera.main;
        minBound = camera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = camera.ViewportToWorldPoint(new Vector2(1, 1));
        minBound += new Vector2(padding, padding);
        maxBound -= new Vector2(padding, padding);
    }

    // Update is called once per frame
    void Update() {
        // Update the player's position based on the moveVector
        transform.position += (Vector3)moveVector * Time.deltaTime * moveSpeed;

        // Clamp the player's position within the screen bounds
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minBound.x, maxBound.x),
            Mathf.Clamp(transform.position.y, minBound.y, maxBound.y)
        );
    }

    // This method is called by the Input System when the Move action is triggered
    public void OnMove(InputValue value) {
        moveVector = value.Get<Vector2>();
        // Debug.Log(moveVector);
    }
    
}
