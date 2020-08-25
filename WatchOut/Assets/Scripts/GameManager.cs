using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int point = 0;
    public int hp = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPoint()
    {
        point += 1;
        Debug.Log("Add 1 point, Total points = " + point);
    }

    public void minusHP()
    {
        hp -= 1;
        Debug.Log("Minus 1 HP, Total HP = " + hp);
    }
}
