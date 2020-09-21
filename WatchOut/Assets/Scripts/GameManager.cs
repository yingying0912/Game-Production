using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int pointRequired;
    private int point = 0;
    public int hp = 10;
    private int currentHP;
    public GameObject loseGameUI;
    public GameObject winGameUI;
    public RandomSpawn Spawning;
    public Text hpText;
    public Text pointText;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = hp;
    }

    // Update is called once per frame
    void Update()
    {
        //TextUpdate();
        if (currentHP == 0)
        {
            loseGameUI.SetActive(true);
            Spawning.gameLose = true;
        }

        if (Spawning.spawnEnd == true && point < pointRequired)
        {
            loseGameUI.SetActive(true);
        }

        if (Spawning.spawnEnd == true && point >= pointRequired)
        {
            winGameUI.SetActive(true);
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

    public void TextUpdate()
    {
        hpText.text = "HP: " + currentHP + " / " + hp;
        pointText.text = "Point: " + point + " / " + pointRequired;
    }
}
