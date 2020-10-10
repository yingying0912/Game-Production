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
    public GameObject strengthEffect;
    public GameObject immuneEffect;

    public GameObject loseGameUI;
    public GameObject winGameUI;
    public RandomSpawn Spawning;

    public AudioClip startGame;
    public AudioClip winGame;
    public AudioClip loseGame;
    public AudioClip[] hitEffect;
    public AudioClip[] hurtEffect;
    public AudioClip strengthCombo;
    public AudioClip immuneCombo;
    public AudioClip normalCombo;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayEffect(startGame);
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
            loseGameUI.SetActive(true);
            Spawning.gameLose = true;
        }

        if (Spawning.spawnEnd)
        {
            
            winGameUI.SetActive(true);
        }
    }

    public void playSound(bool evade)
    {
        if (evade && attackLeft == 0)
            Invoke("triggerWinSound", 0.5f);
        else if (!evade)
        {
            SoundManager.instance.PlayEffect(hitEffect);
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
            TriggerPowerUpEffect();
        }
        if (combo > 5)
        {
            ComboPopup.Create(pfComboPopup, new Vector3(15, 118, 20), combo, "right");
            SoundManager.instance.PlayEffect(normalCombo);
        }
        else if (combo >= 3)
        {
            ComboPopup.Create(pfComboPopup, new Vector3(-15, 118, 20), combo, "left");
            SoundManager.instance.PlayEffect(normalCombo);
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
            SoundManager.instance.PlayMusic(strengthCombo);
            strengthEffect.SetActive(true);
        } 
        else if (powerUp == "immune")
        {
            SoundManager.instance.PlayMusic(immuneCombo);
            SoundManager.instance.musicSource.loop = true;
            strengthEffect.SetActive(false);
            immuneEffect.SetActive(true);
        }        
    }

    private void triggerHurtSound()
    {
        SoundManager.instance.PlayEffect(hurtEffect);
    }

    private void triggerLoseSound()
    {
        SoundManager.instance.PlayEffect(loseGame);
    }

    private void triggerWinSound()
    {
        SoundManager.instance.PlayEffect(winGame);
    }
}
