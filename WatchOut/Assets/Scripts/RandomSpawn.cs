using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    public GameObject[] objects;
    private int randomSpawn = 0;
    public int attackNum;
    public bool gameLose = false;
    public bool spawnEnd = false;
    public Animator animation;
    
    void Start()
    {
        StartCoroutine(Spawn());
        animation = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (gameLose == true)
        {
            StopAllCoroutines();
        }
            
    }
    IEnumerator Spawn()
    {
        for (int i = 0; i < attackNum; i++)
        {
            randomSpawn = Random.Range(0, 4);
            Instantiate(objects[randomSpawn], objects[randomSpawn].transform.position, objects[randomSpawn].transform.rotation);
            if (randomSpawn == 0 && !animation.GetBool("top"))
            {
                animation.SetBool("top", true);
            }
            else
                animation.SetBool("top", false);
            yield return new WaitForSeconds(5f);
        }
        spawnEnd = true;
    }
}
