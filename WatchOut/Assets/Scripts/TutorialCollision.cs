using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCollision : MonoBehaviour
{
    public void checkCollision(Tutorial player, int i)
    {
        switch (i)
        {
            case 0:
                if (transform.rotation.x > 0.45)
                    player.evade = true;
                else
                    player.evade = false;
                break;
            case 1:
                if (transform.rotation.x < -0.45)
                    player.evade = true;
                else
                    player.evade = false;
                break;
            case 2:
                if (transform.rotation.y > 0.45)
                    player.evade = true;
                else
                    player.evade = false;
                break;
            case 3:
                if (transform.rotation.y < -0.45)
                    player.evade = true;
                else
                    player.evade = false;
                break;
        }
    }
    //public Tutorial player;
    /*
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Top")
        {
            if (transform.rotation.x > 0.45)
            {
                player.evade = true;
            }
            else
            {
                player.evade = false;
            }
            
        }
        if (collision.tag == "Right")
        {
            if (transform.rotation.y < -0.45)
            {
                player.evade = true;
            }
            else
            {
                player.evade = false;
            }
        }
        if (collision.tag == "Left")
        {
            if (transform.rotation.y > 0.45)
            {
                player.evade = true;
            }
            else
            {
                player.evade = false;
            }
        }
        if (collision.tag == "Bottom")
        {
            if (transform.rotation.x < -0.45)
            {
                player.evade = true;
            }
            else
            {
                player.evade = false;
            }
        }
    }
    */
}
