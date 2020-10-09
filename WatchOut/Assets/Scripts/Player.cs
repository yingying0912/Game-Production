using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        bool evade = false;

        if (collision.tag == "Top")
        {
            if (transform.rotation.x > 0.45)
                evade = true;
        }
        if (collision.tag == "Right")
        {
            if (transform.rotation.y < -0.45)
                evade = true;
        }
        if (collision.tag == "Left")
        {
            if (transform.rotation.y > 0.45)
                evade = true;
        }
        if (collision.tag == "Bottom")
        {
            if (transform.rotation.x < -0.45)
                evade = true;

        }
        if (evade)
            FindObjectOfType<GameManager>().SetCombo(1);
        else
        {
            FindObjectOfType<GameManager>().minusHP();
            FindObjectOfType<GameManager>().SetCombo(0);  
        }
        FindObjectOfType<GameManager>().playSound(evade);
    }
}
