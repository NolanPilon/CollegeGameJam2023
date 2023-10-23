using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeManager : MonoBehaviour
{
    public static SizeManager Instance;

    //SizeBar
    public Image sizeBar;
    public float sizeAmount = 100f;
    private float sizeBarScaleMultiplier = 2.0f;

    public Image delaySizeBar;

    public int playerSize = 0;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        playerSize = 1;
        sizeBar.fillAmount = 0;
        delaySizeBar.fillAmount = 0;
    }

    public void TakeDamage(int damage)
    {
        if (playerSize > 1) 
        {
            StartCoroutine(delayBarSrink());
            sizeAmount -= damage;
            sizeBar.fillAmount = sizeAmount / 100f;
            playerSize--;
        }
    }

    public void Grow(int growAmount)
    {
        sizeAmount += growAmount * sizeBarScaleMultiplier;
        playerSize += growAmount;
        sizeAmount = Mathf.Clamp(sizeAmount, 0, 100);
        

        sizeBar.fillAmount = sizeAmount / 100f;
    }

    IEnumerator delayBarSrink()
    {
        yield return new WaitForSeconds(1);

        delaySizeBar.fillAmount = sizeAmount / 100f;
    }
}

