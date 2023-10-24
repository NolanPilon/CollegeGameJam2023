using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private const int MAX_ENEMIES = 37;
    private const int MAX_AGRO_ENEMIES = 3;
    public int currentEnemyCount = 0;

    [SerializeField] GameObject[] enemyPrefabs = null;
    [SerializeField] GameObject EnemyContainer = null;

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
        SpawnEnemies(0, 2);
    }

    private void Update()
    {
        if (currentEnemyCount < MAX_ENEMIES && SizeManager.Instance.playerLevel == 1)
        {
            RespawnEnemy(0, 1);
        }

        if (currentEnemyCount < MAX_ENEMIES && SizeManager.Instance.playerLevel >= 2)
        {
            SizeManager.Instance.ShrinkEnemies("EnemyTier1");
            SpawnEnemies(2, 4);
            RespawnEnemy(2, 4);
        }
    }

    void SpawnEnemies(int enemyRange1, int enemyRange2)
    {
        while (currentEnemyCount < MAX_ENEMIES)
        {
            for (int i = 0; i < MAX_ENEMIES; i++)
            {
                int chooseEnemy = Random.Range(enemyRange1, enemyRange2);
                Instantiate(enemyPrefabs[chooseEnemy], EnemyContainer.transform);
                enemyPrefabs[chooseEnemy].transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
                currentEnemyCount++;

                if (currentEnemyCount >= MAX_ENEMIES) 
                {
                    break;
                }
            }
        }

        for (int i = 0; i < MAX_AGRO_ENEMIES; i++)
        {
            Instantiate(enemyPrefabs[2], EnemyContainer.transform);
            enemyPrefabs[2].transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
            currentEnemyCount++;
        }
    }

    void RespawnEnemy(int enemyRange1, int enemyRange2) 
    {
        int chooseEnemy = Random.Range(enemyRange1, enemyRange2);
        Instantiate(enemyPrefabs[chooseEnemy], EnemyContainer.transform);
        enemyPrefabs[chooseEnemy].transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
        currentEnemyCount++;
    }
}
