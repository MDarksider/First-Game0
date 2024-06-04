using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject ammoPrefab; // Ammo Prefab
    public Transform ammoSpawnPoint; // Ammo chiqishi uchun nuqta

    public float shootForce = 1000f; // Ammo chiqarish kuchini belgilash
    public float shootInterval = 3f; // Ammo chiqarishning oraliqi

    private float timeSinceLastShot = 0f; // Ammo chiqarishdan so'ng o'tgan vaqti

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        // Ammo chiqarish uchun harakat
        if (timeSinceLastShot >= shootInterval)
        {
            Shoot();
            timeSinceLastShot = 0f; 

        }
    }


    void Shoot()
    {
        GameObject ammo = Instantiate(ammoPrefab, ammoSpawnPoint.position, ammoSpawnPoint.rotation);
        Rigidbody rb = ammo.GetComponent<Rigidbody>();
        rb.AddForce(ammoSpawnPoint.forward * shootForce);
        Destroy(ammo, 3f);
    }
}