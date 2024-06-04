using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enimy2 : MonoBehaviour
{
    CharacterController controller;
    public Transform player; // Player ob'ekti
    public Transform cylinder; // Cilindr ob'ekti
    public float followSpeed = 0.5f; // Cilindrning playerga qo'shilish tezligi
    bool nima = true;
    int collisionCounter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            nima = true;
        }
        if (collision.gameObject.name == "bullet(Clone)")
        {
            collisionCounter++;
           
            Destroy(collision.gameObject);

            if (collisionCounter == 3)
            {
                            
                Destroy(gameObject);
               
            }
        }
    }
    void Enimy22Move()
        {
            Vector3 directionToPlayer = player.position - cylinder.position;
            Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer, Vector3.up);
            cylinder.rotation = Quaternion.Lerp(cylinder.rotation, rotationToPlayer, followSpeed * Time.deltaTime);

            // Cilindrni playerga yo'naltirish
            Vector3 newPosition = player.position - cylinder.forward * 2f; // Cilindrning playerga yaqinlashishi
            cylinder.position = Vector3.Lerp(cylinder.position, newPosition, followSpeed * Time.deltaTime);
        }  

    void Update()
    {

        if (nima) 
        {
            Enimy22Move();
        }
        


    }
}

