using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFighter : MonoBehaviour {
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject gun;

  
    bool isRunnig; 
    private void Start() {
        if (laser == null) {
            Debug.LogError("Laser prefab is not assigned.");
        }
        if (gun == null) {
            Debug.LogError("Gun game object is not assigned.");
        }

        // Start shooting as soon as the game starts
        

    }
    private void Update() {
        if (!isRunnig) {
            isRunnig = true;
            StartCoroutine(Fire());
        }
    }
    private IEnumerator Fire() {
        Shoot();
        yield return new WaitForSeconds(fireRate);
        isRunnig = false;
    }

    private void Shoot() {
        if (laser != null && gun != null) {
            GameObject _laser = Instantiate(laser, gun.transform.position, transform.rotation);
            _laser.GetComponent<Laser>().FireLaser(-transform.up);
        }
    }
}
