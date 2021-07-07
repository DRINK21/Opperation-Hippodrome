using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSpawner : MonoBehaviour
{
    public enum SpawnState { Spawning, Waiting, Counting };

    private Transform player;

    public Wave[] waves;
    //public Transform[] spawnPoints;
    private int nextWave = 0;
    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    private float searchCountdown = 1f;
    private float workDistance = 13f;

    private SpawnState state = SpawnState.Counting;

    // Start is called before the first frame update
    void Start()
    {
        waveCountdown = timeBetweenWaves;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.Waiting)
        {
            if (!EnemyIsAlive())
            {
                Debug.Log("Wave Completed");
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public Transform enemy;
        public int enemyAmount;
        public float rate;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave");
        state = SpawnState.Spawning;
        for (int i = 0; i < _wave.enemyAmount; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate); // after enemies spawned waits for wave.rate seconds
        }

        state = SpawnState.Waiting;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy");
        //Transform spawnPointRandom = spawnPoints[Random.Range(0, spawnPoints.Length)];
        //Instantiate(_enemy, spawnPointRandom.position, spawnPointRandom.rotation);
        Instantiate(_enemy, transform.position, transform.rotation);
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Restarting Waves");
        }
        else
        {
            nextWave++;
        }
    }


}

