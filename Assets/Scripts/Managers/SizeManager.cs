using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SizeManager : MonoBehaviour
{
    public static SizeManager Instance;

    //SizeBar
    public Image sizeBar;
    public float sizeAmount = 0.0f;
    private float sizeBarScaleMultiplier = 2.0f;

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
    }

    public void Grow(int growAmount)
    {
        sizeAmount += growAmount * sizeBarScaleMultiplier;
        sizeAmount = Mathf.Clamp(sizeAmount, 0, 100);
        

        sizeBar.fillAmount = sizeAmount / 100f;
    }
    public bool isFull()
    {
        if (sizeBar.fillAmount == 1 || sizeBar.fillAmount > 1)
        {
            sizeBar.fillAmount = 0;
            sizeAmount = 0.0f;
            playerLevel++;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ShrinkEnemies(string enemyTierTag)
    {
        GameObject[] enemiesToDelete = GameObject.FindGameObjectsWithTag(enemyTierTag);

        for (int i = 0; i < enemiesToDelete.Length; i++)
        {
            SpawnManager.Instance.currentEnemyCount--;
            Destroy(enemiesToDelete[i]);
        }
    }
}

