using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RandomSpawn : MonoBehaviour
{
    private int randomSpawn = -1;
    public int attackNum = 0;
    private float desiredSpeed;
    private float normalSpeed;

    public bool gameLose = false;
    private bool endAnimation = false;

    public Animator animation;
    public GameObject enemyModel;
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
        desiredSpeed = 0.2f;
        normalSpeed = animation.speed;
        animation.speed = normalSpeed * desiredSpeed;
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5f);
        
        while (!gameLose)
        {
            isIn = false;

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
            yield return new WaitForSeconds(animationLength / desiredSpeed);
            attackNum++;
            if (attackNum % 3 == 0)
            {
                desiredSpeed += 0.05f;
                animation.speed = normalSpeed * desiredSpeed;
            }
        }
    }

    private void Update()
    {

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
                    collisionChecker.checkCollision(randomSpawn, true);
                    isIn = true;
                }
                break;
            case 1:
                if (rightHand.transform.position.z <= 15 && !isIn)
                {
                    collisionChecker.checkCollision(randomSpawn, true);
                    isIn = true;
                }
                break;
            case 2:
                if (rightHand.transform.position.z <= 4.4 && !isIn)
                {
                    collisionChecker.checkCollision(randomSpawn, true);
                    isIn = true;
                }
                break;
            case 3:
                if (leftHand.transform.position.x <= -19 && !isIn)
                {
                    collisionChecker.checkCollision(randomSpawn, true);
                    isIn = true;
                }
                break;
        }
    }
}
