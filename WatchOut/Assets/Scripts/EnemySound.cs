using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public AudioSource enemySource;
    public AudioClip[] swingsEffect;

    public void PlaySwing()
    {
        int index = Random.Range(0, swingsEffect.Length);

        enemySource.PlayOneShot(swingsEffect[index]);
    }
}
