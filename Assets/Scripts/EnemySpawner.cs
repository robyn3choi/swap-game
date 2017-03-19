using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject EnemyPrefab;
    public GameObject[] enemies;
    public int poolSize = 312;

    public Transform[] spawnPoints;

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
        for (int i=0; i<poolSize; i++) {
            enemies[i] = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            enemies[i].GetComponent<RobynEnemy>().alive = false;
        }
    }

    public void SpawnEnemyWave() {
        print("spawnwave");
        for (int i=0; i<spawnPoints.Length; i++) {
            for (int j=0; j<poolSize; j++) {
                if (enemies[j].GetComponent<RobynEnemy>().alive = false) {
                    enemies[i].transform.position = spawnPoints[i].position;
                    enemies[i].GetComponent<RobynEnemy>().alive = true;
                    break;
                }
            }
        }
    }

}
