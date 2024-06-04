using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAnimy : MonoBehaviour
{

    public Transform player; // Player ob'ekti
    public Transform cylinder; // Cilindr ob'ekti
    public float followSpeed = 0.5f; // Cilindrning playerga qo'shilish tezligi


 
    void Update()
    {

        // Cilindr ob'ektini player ob'ektiga qarab ko'rsatish
        Vector3 directionToPlayer = player.position - cylinder.position;
        Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer, Vector3.up);
        cylinder.rotation = Quaternion.Lerp(cylinder.rotation, rotationToPlayer, followSpeed * Time.deltaTime);

        // Cilindrni playerga yo'naltirish
        Vector3 newPosition = player.position - cylinder.forward * 2f; // Cilindrning playerga yaqinlashishi
        cylinder.position = Vector3.Lerp(cylinder.position, newPosition, followSpeed * Time.deltaTime);


    }
        
    
}