using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    private int randomSpawn = -1;
    public int attackNum;
    public int attackLeft;
    public bool gameLose = false;
    public bool spawnEnd = false;
    public Animator animation;
    public GameObject enemyModel;
    public float desiredSpeed;
    private bool endAnimation = false;
    public GameObject rightFoot;
    public GameObject rightHand;
    public GameObject leftHand;
    public Player collisionChecker;
    public bool isIn = true;
    public Animator animator;
    public float animationLength;

    void Start()
    {
        StartCoroutine(Spawn());
        animation = enemyModel.GetComponent<Animator>();
        animation.speed *= desiredSpeed;
        attackLeft = attackNum;
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5f);

        for (int i = 0; i < attackNum; i++)
        {
            isIn = false;
            attackLeft--;
            randomSpawn = Random.Range(0, 4);
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
            animationLength = animator.GetCurrentAnimatorClipInfo(0).Length +
                animator.GetNextAnimatorClipInfo(0).Length;
            if (i != attackNum - 1)
                yield return new WaitForSeconds(animationLength / desiredSpeed);
            else
                yield return new WaitForSeconds(5f);
        }
        spawnEnd = true;
    }

    private void Update()
    {
        if (endAnimation == false && spawnEnd == true)
        {
            animation.SetTrigger("win");
            endAnimation = true;
        }

        if (endAnimation == false && gameLose == true)
        {
            animation.SetTrigger("lose");
            StopAllCoroutines();
            endAnimation = true;
        }

        switch (randomSpawn)
        {
            case 0:
                if (rightFoot.transform.position.z <= 7.1 && !isIn)
                {
                    collisionChecker.checkCollision(randomSpawn, false);
                    isIn = true;
                }
                break;
            case 1:
                if (rightHand.transform.position.z <= 15 && !isIn)
                {
                    collisionChecker.checkCollision(randomSpawn, false);
                    isIn = true;
                }
                break;
            case 2:
                if (rightHand.transform.position.z <= 4.4 && !isIn)
                {
                    collisionChecker.checkCollision(randomSpawn, false);
                    isIn = true;
                }
                break;
            case 3:
                if (leftHand.transform.position.x <= -19 && !isIn)
                {
                    collisionChecker.checkCollision(randomSpawn, false);
                    isIn = true;
                }
                break;
        }
    }
}
