using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    CharacterController _controller;

    int _collisionCounter = 0;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _controller.detectCollisions = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            _collisionCounter++;
            GameManager.Instance.LifeChecker();
            Destroy(collision.gameObject);

            if (_collisionCounter == 3)
            {
                
               
                GameManager.Instance.winnerText.text = "Game Over";
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

}
