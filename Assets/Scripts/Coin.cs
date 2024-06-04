using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;
    AudioSource _m_MyAudioSource;

    void Start()
    {
        _m_MyAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }


    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Checker>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name == "Player")
        {
            GameManager.Instance.IncrementScore();
            Destroy(gameObject);
            _m_MyAudioSource.Play();
            Ground ground = FindObjectOfType<Ground>();
            if (ground != null)
            {
                ground.CoinChecker();
            }
        }

        
    }

}
