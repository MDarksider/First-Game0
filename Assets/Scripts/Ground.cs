using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject coinPrefab;

    private bool _check = true;

    void Start()
    {
        for (int i = 0; 11 > i; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (_check)
        {

            SpawnCoins();
            CoinChecker();
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        point.y = 1;
        return point;
    }

    void SpawnCoins()
    {
        
        GameObject coin = Instantiate(coinPrefab);
        coin.transform.position = GetRandomPointInCollider(GetComponent<Collider>());

    }

 
    public void CoinChecker()
    {
        _check = !_check;
    }



}
