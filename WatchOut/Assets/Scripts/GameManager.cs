using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int pointRequired;
    private int point = 0;
    public int hp = 10;
    private int currentHP;
    public GameObject loseGameUI;
    public RandomSpawn Spawning;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP == 0)
        {
            loseGameUI.SetActive(true);
            Spawning.gameLose = true;
        }

        if (Spawning.spawnEnd == true && point < pointRequired)
        {
            loseGameUI.SetActive(true);
        }

        
    }

    public void addPoint()
    {
        point += 1;
        Debug.Log("Add 1 point, Total points = " + point);
    }

    public void minusHP()
    {
        currentHP -= 1;
        Debug.Log("Minus 1 HP, Total HP = " + hp);
    }
}
