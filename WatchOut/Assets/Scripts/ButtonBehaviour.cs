using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{

    private bool isLookedAt = false;
    public float timerDuration = 2f;
    public float lookTimer = 0f;

    public AudioClip buttonIn;

    // Update is called once per frame
    void Update()
    {
        if (isLookedAt)
        {
            lookTimer += Time.deltaTime;


            if (lookTimer > timerDuration)
            {
                lookTimer = 0f;
                Debug.Log("Button selected!");
                GetComponent<Button>().onClick.Invoke();
            }
        }
        else
        {
            lookTimer = 0f;
        }
    }

    public void SetGazeAt(bool gazedAt)
    {
        isLookedAt = gazedAt;
        SoundManager.instance.PlayEffect(buttonIn);
    }

}
