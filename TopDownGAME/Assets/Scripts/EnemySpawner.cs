using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Enemies Prefabs
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private GameObject EnemyShootPrefab;


    private float EnemySpawnRate = 1;
    private float EnemyShootSpawnRate = 5;

    void Start()
    {
        StartCoroutine(Spawn(EnemySpawnRate, EnemyPrefab));
        StartCoroutine(Spawn(EnemyShootSpawnRate, EnemyShootPrefab));
    }

    private IEnumerator Spawn(float interval, GameObject enemy)
    {
        Debug.Log(EnemySpawnRate);
        Debug.Log(EnemyShootSpawnRate);
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        EnemySpawnRate = Random.Range(1, 30f);
        EnemyShootSpawnRate = Random.Range(1, 30f);
        StartCoroutine(Spawn(interval, enemy));
    }
}

//EnemySpawnRate = Random.Range(1, 4f);
//EnemyShootSpawnRate = Random.Range(4, 20f);