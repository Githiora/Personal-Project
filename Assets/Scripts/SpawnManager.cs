using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject powerUp;

    private float xSpawnRange = 10;
    private float yEnemySpawn = 0.8f;
    private float zEnemySpawn = 9f;
    private float zPowerUpSpawnMax = 5;

    private float powerUpSpawnTime = 5;
    private float enenmySpawnTime = 1;
    private float startDelay = 1;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enenmySpawnTime);
        InvokeRepeating("SpawnPowerUp", startDelay, powerUpSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomEnemy()
    {
        int randomEnemyIndex = Random.Range(0, enemies.Length);
        float xRandomPosition = Random.Range(-xSpawnRange, xSpawnRange);
        Vector3 enemyPosition = new Vector3(xRandomPosition, yEnemySpawn, zEnemySpawn);
        Instantiate(enemies[randomEnemyIndex], enemyPosition, enemies[randomEnemyIndex].transform.rotation);
    }

    void SpawnPowerUp()
    {
        float xRandomPosition = Random.Range(-xSpawnRange, xSpawnRange);
        float zRandomPosition = Random.Range(0, zPowerUpSpawnMax);
        Vector3 powerUpPosition = new Vector3(xRandomPosition, yEnemySpawn, zRandomPosition);
        Instantiate(powerUp, powerUpPosition, powerUp.transform.rotation);
    }
}
