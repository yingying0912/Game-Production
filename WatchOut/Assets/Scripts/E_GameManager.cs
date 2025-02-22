﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_GameManager : MonoBehaviour
{
    private int maxHP = 10;
    private int currentHP;
    public HealthBar healthBar;

    public int attackNum;
    public Text t_attackNum;
    public Text t_finalScore;

    public int combo = 0;
    public Transform pfComboPopup;

    public string powerUp;
    public StrengthBar strengthBar;
    public ImmuneBar immuneBar;
    public GameObject strengthEffect;
    public GameObject immuneEffect;

    public GameObject endGameUI;
    public E_RandomSpawn Spawning;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("start");
        currentHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        AttackUpdate();
        CheckCombo();
        if (currentHP <= 0)
        {
            endGameUI.SetActive(true);
            Spawning.gameLose = true;
        }
    }

    public void playSound(bool evade)
    {
        if (!evade)
        {
            FindObjectOfType<AudioManager>().PlayRandom("hit_effect");
            if (currentHP <= 0)
                Invoke("triggerLoseSound", 0.5f);
            else
                Invoke("triggerHurtSound", 0.5f);
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
        attackNum = Spawning.attackNum;
        t_attackNum.text = attackNum.ToString();
        t_finalScore.text = attackNum.ToString();
    }

    public void SetCombo(int num)
    {
        if (num == 1)
            combo++;
        else
        {
            combo = 0;
            powerUp = "";
            TriggerPowerUpEffect();
        }
        if (combo > 5)
        {
            ComboPopup.Create(pfComboPopup, new Vector3(15, 118, 20), combo, "right");
            FindObjectOfType<AudioManager>().Play("combo");
        }
        else if (combo >= 3)
        {
            ComboPopup.Create(pfComboPopup, new Vector3(-15, 118, 20), combo, "left");
            FindObjectOfType<AudioManager>().Play("combo");
        }
    }

    public void CheckCombo()
    {
        if (combo == 10 && powerUp != "immune")
        {
            powerUp = "immune";
            TriggerPowerUpEffect();
        }
        else if (combo == 5 && powerUp != "stronger")
        {
            powerUp = "stronger";
            TriggerPowerUpEffect();
        }

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

    public void TriggerPowerUpEffect()
    {
        if (powerUp == "")
        {
            strengthEffect.SetActive(false);
            immuneEffect.SetActive(false);
        }
        else if (powerUp == "stronger")
        {
            FindObjectOfType<AudioManager>().Play("strength");
            strengthEffect.SetActive(true);
        }
        else if (powerUp == "immune")
        {
            FindObjectOfType<AudioManager>().Play("immune");
            strengthEffect.SetActive(false);
            immuneEffect.SetActive(true);
        }
    }

    private void triggerHurtSound()
    {
        FindObjectOfType<AudioManager>().PlayRandom("hurt_effect");
    }

    private void triggerLoseSound()
    {
        FindObjectOfType<AudioManager>().Play("lose");
    }
}
