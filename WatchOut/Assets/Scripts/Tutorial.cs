using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] objects;
    public bool evade = false;
    public GameObject[] arrows;
    public GameObject tutorialEnd;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tutStart());     
        
    }

    IEnumerator tutStart()
    {
        for(int i = 0; i < 4; i++)
        {
            while (!evade)
            {
                Instantiate(objects[i], objects[i].transform.position, objects[i].transform.rotation);
                arrows[i].SetActive(true);
                yield return new WaitForSeconds(5f);
            }
            arrows[i].SetActive(false);
            evade = false;
        }
        tutorialEnd.SetActive(true);        
    }
}
