using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxHP = 10;
    private int currentHP;
    public HealthBar healthBar;

    public int attackLeft;
    public Text t_attackLeft;

    public int combo = 0;
    public Transform pfComboPopup;

    public string powerUp;
    public StrengthBar strengthBar;
    public ImmuneBar immuneBar;

    public GameObject loseGameUI;
    public GameObject winGameUI;
    public RandomSpawn Spawning;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        AttackUpdate();
        CheckCombo();
        if (currentHP < 0)
        {
            loseGameUI.SetActive(true);
            Spawning.gameLose = true;
        }

        if (Spawning.spawnEnd)
        {
            winGameUI.SetActive(true);
        }
    }

    public void minusHP()
    {
        if (powerUp == "stronger")
            currentHP--;
        else if (powerUp == "")
            currentHP -= 2;
        healthBar.SetHealth(currentHP);
    }

    public void AttackUpdate()
    {
        attackLeft = Spawning.attackLeft;
        t_attackLeft.text = attackLeft.ToString();
    }

    public void SetCombo(int num)
    {
        if (num == 1)
            combo++;
        else
        {
            combo = 0;
            powerUp = "";
        }
        if (combo > 5) 
            ComboPopup.Create(pfComboPopup, new Vector3(28, 118, 46), combo);
        else if (combo >= 3)
            ComboPopup.Create(pfComboPopup, new Vector3(-28, 118, 46), combo);
    }

    public void CheckCombo()
    {
        if (combo >= 10)
            powerUp = "immune";
        else if (combo >= 5)
            powerUp = "stronger";

        if (combo == 0)
        {
            strengthBar.SetStrength(combo);
            immuneBar.SetImmune(combo - 5);
        }
        else if (combo <= 5)
            strengthBar.SetStrength(combo);
        else if (combo <= 10)
            immuneBar.SetImmune(combo - 5);
    }

    /*
    public void GenerateComboPopup()
    {
        Transform comboPopupTransform = Instantiate(pfComboPopup, new Vector3(28, 118, 46), Quaternion.identity);
        ComboPopup comboPopup = comboPopupTransform.GetComponent<ComboPopup>();
        comboPopup.Setup(combo);
    }
    */
}
