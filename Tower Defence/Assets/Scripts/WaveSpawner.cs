using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    //Using prefab to choose which enemy we wanna spawn
    public Transform[] enemyPrefabs = new Transform[2];
    public Transform enemySpawnLocation;
    public float timeBetweenWaves = 5f;

    //Variable contains number of enemies to spawn each wave
    public int[] enemiesAmount = { 3,5,9,12 };

    //Time before first wave start running
    private float countdown = 5f;

    private int waveNumber = 0;

    private void Update()
    {
        if (countdown <= 0 && waveNumber < enemiesAmount.Length)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;

        for (int i = 0; i < enemiesAmount[waveNumber-1]; i++)
        {
            SpawnEnemy(enemyPrefabs[0]);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy(Transform enemyToSpawn)
    {
        Instantiate(enemyToSpawn, enemySpawnLocation.position, enemySpawnLocation.rotation);
    }
}
