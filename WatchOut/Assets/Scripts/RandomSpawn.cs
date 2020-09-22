using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    public GameObject[] objects;
    private int randomSpawn = 0;
    public int attackNum;
    public int attackLeft;
    public bool gameLose = false;
    public bool spawnEnd = false;
    public Animator animation;
    public GameObject enemyModel;
    public float desiredSpeed;
    private bool endAnimation = false;
    
    void Start()
    {
        StartCoroutine(Spawn());
        animation = enemyModel.GetComponent<Animator>();
        animation.speed *= desiredSpeed;
        attackLeft = attackNum - 1;
    }

    private void Update()
    {
        if (endAnimation == false && gameLose == true)
        {
            animation.SetTrigger("lose");
            StopAllCoroutines();
            endAnimation = true;
        }

        if (endAnimation == false && spawnEnd == true)
        {
            animation.SetTrigger("win");
            endAnimation = true;
        }
            
    }
    IEnumerator Spawn()
    {
        for (int i = 0; i < attackNum; i++)
        {
            attackLeft--;
            randomSpawn = Random.Range(0, 4);
            Instantiate(objects[randomSpawn], objects[randomSpawn].transform.position, objects[randomSpawn].transform.rotation);
            switch (randomSpawn)
            {
                case 0:
                    animation.SetTrigger("top");
                    break;
                case 1:
                    animation.SetTrigger("bot");
                    break;
                case 2:
                    animation.SetTrigger("left");
                    break;
                case 3:
                    animation.SetTrigger("right");
                    break;
            }
            yield return new WaitForSeconds(5f);
        }
        spawnEnd = true;
    }
}
