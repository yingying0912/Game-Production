using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboPopup : MonoBehaviour
{
    
    public static ComboPopup Create(Transform pfComboPopup, Vector3 position, int comboAmount)
    {
        Transform comboPopupTransform = Instantiate(pfComboPopup, position, Quaternion.identity);
        ComboPopup comboPopup = comboPopupTransform.GetComponent<ComboPopup>();
        comboPopup.Setup(comboAmount);

        return comboPopup;
    }

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup (int comboAmount)
    {
        if (comboAmount >= 3)
        {
            textMesh.SetText("combo x" + comboAmount.ToString());

            if (comboAmount == 5 || comboAmount == 10)
                textMesh.fontSize = 55;

            if (comboAmount > 5)
            {
                textMesh.color = new Color(0.25f, 1f, 0.99f);
                Color colorTopRight = new Color(0.7f, 0.57f, 0.9f);
                Color colorTopLeft = new Color(0.28f, 0.5f, 0.9f);
                Color colorOutline = new Color(0f, 0f, 1f);
                textMesh.colorGradient = new VertexGradient (colorTopRight, colorTopLeft, Color.white, Color.white);
                textMesh.outlineColor = colorOutline;
            }                
        }
        
        textColor = textMesh.color;
        disappearTimer = 2f;
    }
    
    void Update()
    {
        float moveXSpeed = 1f;
        float moveZSpeed = 2f;
        transform.position += new Vector3(moveXSpeed, 0, moveZSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 2f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
                Destroy(gameObject);
        }
    }
}
