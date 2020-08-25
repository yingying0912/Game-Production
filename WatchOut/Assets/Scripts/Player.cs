using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.rotation);
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Top")
        {
            
            if (transform.rotation.x > 0.5)
            {
                gameManager.addPoint();
            }
            else
            {
                gameManager.minusHP();
            }
        }
        if (collision.tag == "Right")
        {
            if (transform.rotation.y < -0.5)
            {
                gameManager.addPoint();
            }
            else
            {
                gameManager.minusHP();
            }
        }
        if (collision.tag == "Left")
        {
            if (transform.rotation.y > 0.5)
            {
                gameManager.addPoint();
            }
            else
            {
                gameManager.minusHP();
            }
        }
        if (collision.tag == "Bottom")
        {
            if (transform.rotation.x < -0.5)
            {
                gameManager.addPoint();
            }
            else
            {
                gameManager.minusHP();
            }
        }
    }

}
