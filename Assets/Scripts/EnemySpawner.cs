using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public int poolSize = 256;
    public Transform[] spawnPoints;
    public float spawnDelay = 0.1f;

    private List<GameObject> enemies;
    public int waveSize = 5;

    public static EnemySpawner instance = null;

    void Awake() {
        if (instance == null) {
            instance = this;
        }    
        else if (instance != this) {
            Destroy(gameObject);
        }
    }

    void Start () {
        Init();
    }

    void Init()
    {
        enemies = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = (GameObject)Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }
    }

    public void EndGame()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
    }

    public void ResetEnemies()
    {
        EndGame();
        Init();
    }

    public void SpawnEnemyWave() {
        
        List<GameObject> enemiesToSpawn = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = enemies[i];
            if (!enemy.activeSelf)
            {
                enemiesToSpawn.Add(enemy);
            }

            if (enemiesToSpawn.Count == waveSize) {
                StartCoroutine(Spawn(enemiesToSpawn));
                break;
            }
        }
        waveSize += 5;
    }

    IEnumerator Spawn(List<GameObject> enemiesToSpawn)
    {
        foreach (GameObject enemy in enemiesToSpawn) {
            yield return new WaitForSeconds(spawnDelay);
            enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            enemy.GetComponent<Enemy>().health = 2;
            enemy.SetActive(true);
        }
    }

}
