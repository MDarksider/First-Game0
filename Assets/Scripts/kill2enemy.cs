using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill2enemy : MonoBehaviour
{
  
    CharacterController controller;
    public Transform player;
    public Transform player22;// Player ob'ekti
    public Transform cylinder; // Cilindr ob'ekti
    public float followSpeed = 0.5f; // Cilindrning playerga qo'shilish tezligi
    bool nima = true;
    private Transform tirik;


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            nima = true;
        }
    }
   private  void Enimy22Move()
    {
        Vector3 directionToPlayer = tirik.position - cylinder.position;
        Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer, Vector3.up);
        cylinder.rotation = Quaternion.Lerp(cylinder.rotation, rotationToPlayer, followSpeed * Time.deltaTime);

        // Cilindrni playerga yo'naltirish
        Vector3 newPosition = tirik.position - cylinder.forward * 2f; // Cilindrning playerga yaqinlashishi
        cylinder.position = Vector3.Lerp(cylinder.position, newPosition, followSpeed * Time.deltaTime);
    }

  

    void Update()
    {

        if (nima)
        {
            Enimy22Move();
        }

        if(player22 != null)
        {
            tirik = player22;
        }
        else
        {
            tirik = player;
        }


    }
}

