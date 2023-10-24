using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SizeManager : MonoBehaviour
{
    public static SizeManager Instance;

    //SizeBar
    public Image sizeBar;
    public float sizeAmount = 0.0f;
    private float sizeBarScaleMultiplier = 2.0f;

    public Image delaySizeBar;

    public int playerLevel = 0;



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
        playerLevel = 1;
        sizeBar.fillAmount = 0;
        delaySizeBar.fillAmount = 0;
    }

    public void TakeDamage(int damage)
    {
        if (sizeAmount > 0) 
        {
            StartCoroutine(delayBarSrink());
            CameraManager.Instance.CameraShake(0.3f, 0.2f);
            sizeAmount -= damage;
            sizeBar.fillAmount = sizeAmount / 100f;
        }
    }

    public void Grow(int growAmount)
    {
        sizeAmount += growAmount * sizeBarScaleMultiplier;
        sizeAmount = Mathf.Clamp(sizeAmount, 0, 100);
        

        sizeBar.fillAmount = sizeAmount / 100f;
    }

    IEnumerator delayBarSrink()
    {
        yield return new WaitForSeconds(1);

        delaySizeBar.fillAmount = sizeAmount / 100f;
    }


    public bool isFull()
    {
        if (sizeBar.fillAmount == 1 || sizeBar.fillAmount > 1)
        {
            sizeBar.fillAmount = 0;
            sizeAmount = 0.0f;
            return true;
        }
        else
        {
            return false;

            //Shrink enmemies when level up
            void ShrinkEnemies(string enemyTierTag)
            {
                GameObject[] enemiesToDelete = GameObject.FindGameObjectsWithTag(enemyTierTag);

                for (int i = 0; i < enemiesToDelete.Length; i++)
                {
                    if (enemiesToDelete[i].transform.localScale.x <= 0.25f)
                    {
                        Destroy(enemiesToDelete[i]);
                    }

                    enemiesToDelete[i].transform.localScale /= 2;
                }
            }
        }
    }
}

