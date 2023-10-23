using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private int health = 3;
    public TextMeshProUGUI healthText;

    void Update()
    {
        healthText.text = "HEALTH : " + health;
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
    }
}
