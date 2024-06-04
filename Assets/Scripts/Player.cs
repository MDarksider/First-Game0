using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int _collisionCounter = 0;
    public float health = 100f; // Obyekt hayoti

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet")
        {
            _collisionCounter++;

            // Ammo ob'ektini o'chirish
            Destroy(collision.gameObject);

            if (_collisionCounter == 3)
            {
                // Player ob'ektini o'chirish
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        // Agar hayot 0 dan kam bo'lsa, ob'ekt o'chiriladi
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    // Obyektga zarar yetkazish
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
