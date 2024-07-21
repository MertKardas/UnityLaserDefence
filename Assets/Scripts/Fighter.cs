using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fighter : MonoBehaviour {
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject gun;
    [SerializeField] private float laserLifeTime = 15f;

    private bool isFiring = false;
    private Rigidbody2D rb2d;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        if (laser == null) {
            Debug.LogError("Laser prefab is not assigned.");
        }
        if (gun == null) {
            Debug.LogError("Gun game object is not assigned.");
        }
    }

    public void OnFire(InputValue inputValue) {
        float value = inputValue.Get<float>();
        if (!isFiring && value == 1) {
            OnFireStarted();
        } else if (isFiring && value == 0) {
            OnFireCanceled();
        }
    }

    public void OnFireStarted() {
        isFiring = true;
        StartCoroutine(Fire());
    }

    public void OnFireCanceled() {
        isFiring = false;
    }

    private IEnumerator Fire() {
        while (isFiring) {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Shoot() {
        if (laser != null && gun != null) {
            GameObject _laser = Instantiate(laser, gun.transform.position, Quaternion.identity);
            Rigidbody2D laserRb2d = _laser.GetComponent<Rigidbody2D>();
            if (laserRb2d != null) {
                laserRb2d.velocity = new Vector2(0, 5f) + rb2d.velocity;
            }
            Destroy(_laser, laserLifeTime);
        }
    }
}
