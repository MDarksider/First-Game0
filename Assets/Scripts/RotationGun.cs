using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGun : MonoBehaviour
{
    public float turnSpeed=30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, turnSpeed*Time.deltaTime, 0);
    }
}
