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

    public Image delaySizeBar;
  

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamager(20);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Grow(20);
        }
    }

    public void TakeDamager(float damage)
    {
        StartCoroutine(delayBarSrink());
        sizeAmount -= damage;
        sizeBar.fillAmount = sizeAmount / 100f;


    }

    public void Grow(float growAmount)
    {
        sizeAmount += growAmount;
        sizeAmount = Mathf.Clamp(sizeAmount, 0, 100);

        sizeBar.fillAmount = sizeAmount / 100f;
    }

    IEnumerator delayBarSrink()
    {
        yield return new WaitForSeconds(1);

        delaySizeBar.fillAmount = sizeAmount / 100f;

        Debug.Log("fuck");
    }
}

