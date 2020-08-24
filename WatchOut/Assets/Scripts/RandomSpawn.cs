using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    public GameObject[] objects;
    private int randomSpawn = 0;
    public int attackNum;

    void Start()
    {
        
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        for (int i = 0; i < attackNum; i++)
        {
            randomSpawn = Random.Range(0, 4);
            Instantiate(objects[randomSpawn], objects[randomSpawn].transform.position, objects[randomSpawn].transform.rotation);
            yield return new WaitForSeconds(5f);
        }
        
    }
}
