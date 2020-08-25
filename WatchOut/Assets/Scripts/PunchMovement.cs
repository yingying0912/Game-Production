using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchMovement : MonoBehaviour
{

    public Rigidbody rg;
    public GameObject camera;
    public Vector3 velocity;

    // Update is called once per frame
    void Start()
    {        
        velocity = camera.transform.position - transform.position;
        velocity.Normalize();
        velocity *= 5;
    }

    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        if (transform.position.z < 0)
        {
            Destroy(gameObject);
        }
    }

    

}
