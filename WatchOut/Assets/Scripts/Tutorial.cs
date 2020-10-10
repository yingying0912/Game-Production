using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public TutorialCollision collisionChecker;

    public bool evade = false;
    public GameObject[] arrows;
    public GameObject tutorialEnd;
    public GameObject enemyModel;
    public Animator animation;
    public float desiredSpeed;
    private int i;
    private bool isIn = true;
    public GameObject rightFoot;
    public GameObject rightHand;
    public GameObject leftHand;
    public Animator animator;
    public float animationLength;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tutStart());
        animation = enemyModel.GetComponent<Animator>();
        animation.speed *= desiredSpeed;
    }

    IEnumerator tutStart()
    {
        FindObjectOfType<AudioManager>().Play("start");
        yield return new WaitForSeconds(5f);

        for(i = 0; i < 4; i++)
        {
            while (!evade)
            {
                isIn = false;
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
                        animation.SetTrigger("left");
                        break;
                    case 3:
                        animation.SetTrigger("right");
                        break;
                }
                animationLength = animator.GetCurrentAnimatorClipInfo(0).Length +
                    animator.GetNextAnimatorClipInfo(0).Length;
                if (i != 3)
                    yield return new WaitForSeconds(animationLength / desiredSpeed);
                else
                    yield return new WaitForSeconds(5f);
                if (!evade)
                {
                    FindObjectOfType<AudioManager>().PlayRandom("hit_effect");
                    Invoke("triggerHurtSound", 0.5f);
                }
                else
                    Invoke("triggerEvadeSound", 0.5f);
            }
            arrows[i].SetActive(false);
            evade = false;
        }
        yield return new WaitForSeconds(1f);
        FindObjectOfType<AudioManager>().Play("win");
        tutorialEnd.SetActive(true);
        animation.SetTrigger("win");
    }

    private void Update()
    {
        switch (i)
        {
            case 0:
                if (rightFoot.transform.position.z <= 7.1 && !isIn)
                {
                    collisionChecker.checkCollision(this, i);
                    isIn = true;
                }     
                break;
            case 1:
                if (rightHand.transform.position.z <= 15 && !isIn)
                {
                    collisionChecker.checkCollision(this, i);
                    isIn = true;
                }
                    
                break;
            case 2:
                if (rightHand.transform.position.z <= 4.4 && !isIn)
                {
                    collisionChecker.checkCollision(this, i);
                    isIn = true;
                }
                    
                break;
            case 3:
                if (leftHand.transform.position.x <= -19 && !isIn)
                {
                    collisionChecker.checkCollision(this, i);
                    isIn = true;
                }
                    
                break;
        }
    }

    private void triggerHurtSound()
    {
        FindObjectOfType<AudioManager>().PlayRandom("hurt_effect");
    }

    private void triggerEvadeSound()
    {
        FindObjectOfType<AudioManager>().Play("combo");
    }
}


