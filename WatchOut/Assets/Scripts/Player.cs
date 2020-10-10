using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void checkCollision(int position)
    {
        bool actionEvade = false;

        switch (position)
        {
            case 0:
                if (transform.rotation.x > 0.45)
                    actionEvade = true;
                break;
            case 1:
                if (transform.rotation.x < -0.45)
                    actionEvade = true;
                break;
            case 2:
                if (transform.rotation.y > 0.45)
                    actionEvade = true;
                break;
            case 3:
                if (transform.rotation.y < -0.45)
                    actionEvade = true;
                break;
        }

        if (actionEvade)
        {
            FindObjectOfType<GameManager>().SetCombo(1);
        }
        else
        {
            FindObjectOfType<GameManager>().minusHP();
            FindObjectOfType<GameManager>().SetCombo(0);
        }

        FindObjectOfType<GameManager>().playSound(actionEvade);
    }
}
