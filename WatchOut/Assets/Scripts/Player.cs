using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Top")
        {
            if (transform.rotation.x > 0.5)
                FindObjectOfType<GameManager>().SetCombo(1);
            else
            {
                FindObjectOfType<GameManager>().minusHP();
                FindObjectOfType<GameManager>().SetCombo(0);
            }
        }
        if (collision.tag == "Right")
        {
            if (transform.rotation.y < -0.45)
                FindObjectOfType<GameManager>().SetCombo(1);
            else
            {
                FindObjectOfType<GameManager>().minusHP();
                FindObjectOfType<GameManager>().SetCombo(0);
            }
        }
        if (collision.tag == "Left")
        {
            if (transform.rotation.y > 0.45)
                FindObjectOfType<GameManager>().SetCombo(1);
            else
            {
                FindObjectOfType<GameManager>().minusHP();
                FindObjectOfType<GameManager>().SetCombo(0);
            }
        }
        if (collision.tag == "Bottom")
        {
            if (transform.rotation.x < -0.5)
                FindObjectOfType<GameManager>().SetCombo(1);
            else
            {
                FindObjectOfType<GameManager>().minusHP();
                FindObjectOfType<GameManager>().SetCombo(0);
            }
        }
    }
}
