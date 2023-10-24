using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private const int MAX_ENEMIES = 30;
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
        SpawnEnemies();
    }

    private void Update()
    {
        if (currentEnemyCount < MAX_ENEMIES) 
        {
            RespawnEnemy();
        }
    }

    void SpawnEnemies() 
    {
        while (currentEnemyCount < MAX_ENEMIES) 
        {
            for (int i = 0; i < MAX_ENEMIES; i++)
            {
                int chooseEnemy = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[chooseEnemy], EnemyContainer.transform);
                enemyPrefabs[chooseEnemy].transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
                currentEnemyCount++;
            }
        }
    }

    void RespawnEnemy() 
    {
        int chooseEnemy = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[chooseEnemy], EnemyContainer.transform);
        enemyPrefabs[chooseEnemy].transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
        currentEnemyCount++;
    }
}
