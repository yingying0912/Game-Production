using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] objects;
    public bool evade = false;
    public GameObject[] arrows;
    public GameObject tutorialEnd;
    public GameObject enemyModel;
    public Animator animation;
    public float desiredSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tutStart());
        animation = enemyModel.GetComponent<Animator>();
        animation.speed = desiredSpeed;
    }

    IEnumerator tutStart()
    {
        for(int i = 0; i < 4; i++)
        {
            while (!evade)
            {
                Instantiate(objects[i], objects[i].transform.position, objects[i].transform.rotation);
                arrows[i].SetActive(true);
                switch (i)
                {
                    case 0:
                        animation.SetTrigger("top");
                        break;
                    case 1:
                        animation.SetTrigger("bot");
                        break;
                    case 2:
                        animation.SetTrigger("right");
                        break;
                    case 3:
                        animation.SetTrigger("left");
                        break;
                }
                yield return new WaitForSeconds(5f);
                if (i == 2)
                    yield return new WaitForSeconds(4f);
            }
            arrows[i].SetActive(false);
            evade = false;
        }
        tutorialEnd.SetActive(true);
        animation.SetTrigger("win");
    }
}
