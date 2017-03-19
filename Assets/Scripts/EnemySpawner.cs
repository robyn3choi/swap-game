using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public int poolSize = 256;
    public Transform[] spawnPoints;
    

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
        enemies = new List<GameObject>();
        for (int i=0; i<poolSize; i++) {
            GameObject enemy = (GameObject)Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }

    }

    void Update() { 
        
    }

    public void SpawnEnemyWave() {
        Vector2 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        List<GameObject> enemiesToSpawn = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = enemies[i];
            if (!enemy.activeSelf)
            {
                enemiesToSpawn.Add(enemy);
            }

            if (enemiesToSpawn.Count == waveSize) {
                StartCoroutine(Spawn(1.5f, enemiesToSpawn, spawnPosition));
                break;
            }
        }
    }

    IEnumerator Spawn(float spawnDelay, List<GameObject> enemiesToSpawn, Vector2 position)
    {
        foreach (GameObject enemy in enemiesToSpawn) {
            yield return new WaitForSeconds(spawnDelay);
            enemy.transform.position = position;
            enemy.SetActive(true);
        }
    }

}
