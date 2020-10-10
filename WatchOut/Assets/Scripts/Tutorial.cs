using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tutorial : MonoBehaviour
{
    //public GameObject[] objects;
    public TutorialCollision collisionChecker;

    public bool evade = false;
    public GameObject[] arrows;
    public GameObject tutorialEnd;
    public GameObject enemyModel;
    public Animator animation;
    public float desiredSpeed;
    private int i;
    public GameObject rightFoot;
    public GameObject hip;

    public AudioClip startGame;
    public AudioClip[] hitEffect;
    public AudioClip[] hurtEffect;
    public AudioClip evadeEffect;
    public AudioClip winGame;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tutStart());
        animation = enemyModel.GetComponent<Animator>();
        animation.speed *= desiredSpeed;
    }

    IEnumerator tutStart()
    {
        SoundManager.instance.PlayEffect(startGame);
        yield return new WaitForSeconds(5f);

        for(i = 0; i < 4; i++)
        {
            while (!evade)
            {
                //Instantiate(objects[i], objects[i].transform.position, objects[i].transform.rotation);
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
                yield return new WaitForSeconds(5f);
                if (!evade)
                {
                    SoundManager.instance.PlayEffect(hitEffect);
                    Invoke("triggerHurtSound", 0.5f);
                }
                else
                    Invoke("triggerEvadeSound", 0.5f);
            }
            arrows[i].SetActive(false);
            evade = false;
        }
        yield return new WaitForSeconds(1f);
        SoundManager.instance.PlayEffect(winGame);
        tutorialEnd.SetActive(true);
        animation.SetTrigger("win");
    }

    private void Update()
    {
        switch (i)
        {
            case 0:
                if (rightFoot.transform.position.z >= 1.17)
                    collisionChecker.checkCollision(this, i);
                break;
            case 1:
                if (rightFoot.transform.position.z >= 1.12)
                    collisionChecker.checkCollision(this, i);
                break;
            case 2:
                if (hip.transform.position.z >= 0.078)
                    collisionChecker.checkCollision(this, i);
                break;
            case 3:
                if (hip.transform.position.x >= 0.0129)
                    collisionChecker.checkCollision(this, i);
                break;
        }
    }

    private void triggerHurtSound()
    {
        SoundManager.instance.PlayEffect(hurtEffect);
    }

    private void triggerEvadeSound()
    {
        SoundManager.instance.PlayEffect(evadeEffect);
    }
}


