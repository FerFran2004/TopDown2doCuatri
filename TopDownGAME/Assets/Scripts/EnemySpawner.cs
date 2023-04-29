using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemySpawner : MonoBehaviour
{
    //Enemies Prefabs
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private GameObject EnemyShootPrefab;


    [SerializeField] private float EnemySpawnRate;
    [SerializeField] private float EnemyShootSpawnRate;

    public int EnemiesTotalLimit;
    private GameObject[] EnemyCount;


    public int EnemiesShootTotalLimit;
    private GameObject[] EnemyShootCount;

    

    void Start()
    {
        EnemySpawnRate = Random.Range(1, 5f);
        EnemyShootSpawnRate = Random.Range(1, 10f);
    }
    void Update()
    {
        EnemyCount = GameObject.FindGameObjectsWithTag("Enemies");
        int EnemyTotal = EnemyCount.Length;

        EnemyShootCount = GameObject.FindGameObjectsWithTag("EnemiesShoot");
        int EnemyShootTotal = EnemyShootCount.Length;
        
        //Red Enemies
        if (EnemyTotal < EnemiesTotalLimit)
        {
            if (EnemySpawnRate <= 0)
            {
                Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
                EnemySpawnRate = Random.Range(1, 5f);
            }
            if (EnemySpawnRate > 0)
            {
                EnemySpawnRate -= Time.deltaTime;
            }

        }
        
        //Blue Shoot Enemies
        if (EnemyShootTotal < EnemiesShootTotalLimit)
        {
            if (EnemyShootSpawnRate <= 0)
            {

                Instantiate(EnemyShootPrefab, transform.position, Quaternion.identity);
                EnemyShootSpawnRate = Random.Range(1, 10f);
            }
            if (EnemyShootSpawnRate > 0)
            {
                EnemyShootSpawnRate -= Time.deltaTime;
            }

        }

    }

}
