using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeManager : MonoBehaviour
{
    public static SizeManager instance;

    //SizeBar
    public Image sizeBar;
    public float sizeAmount = 100f;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Grow(20);
        }
    }

    public void TakeDamage(float damage)
    {
        sizeAmount -= damage;
        sizeBar.fillAmount = sizeAmount / 100f;
      }

    public void Grow(float growAmount)
    {
        sizeAmount += growAmount;
        sizeAmount = Mathf.Clamp(sizeAmount, 0, 100);

        sizeBar.fillAmount = sizeAmount / 100f;
    }
}

