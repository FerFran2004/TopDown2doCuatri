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

    public int EnemiesShootTotalLimit;
    private GameObject[] EnemyShootCount;

    void Start()
    {
        EnemySpawnRate = Random.Range(1, 5f);
        EnemyShootSpawnRate = Random.Range(1, 10f);
    }
    void Update()
    {
        EnemyShootCount = GameObject.FindGameObjectsWithTag("EnemiesShoot");
        int EnemyShootTotal = EnemyShootCount.Length;
        
        if (EnemySpawnRate <= 0) 
        {
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            EnemySpawnRate = Random.Range(1, 5f);
            Debug.Log("Enemy Spawn" + EnemySpawnRate);
        }
        if (EnemySpawnRate > 0) 
        {
            EnemySpawnRate -= Time.deltaTime;
        }

        if (EnemyShootTotal < EnemiesShootTotalLimit)
        {
            if (EnemyShootSpawnRate <= 0)
            {

                Instantiate(EnemyShootPrefab, transform.position, Quaternion.identity);
                EnemyShootSpawnRate = Random.Range(1, 10f);
                Debug.Log("Shoot Spawn" + EnemyShootSpawnRate);
            }
            if (EnemyShootSpawnRate > 0)
            {
                EnemyShootSpawnRate -= Time.deltaTime;
            }


        }
        else
        {

        }

    }


}

//EnemySpawnRate = Random.Range(1, 4f);
//EnemyShootSpawnRate = Random.Range(4, 20f);


////Enemies Prefabs
//[SerializeField] private GameObject EnemyPrefab;
//[SerializeField] private GameObject EnemyShootPrefab;
//
//
//private float EnemySpawnRate = 1;
//private float EnemyShootSpawnRate = 5;
//
//void Start()
//{
//    StartCoroutine(Spawn(EnemySpawnRate, EnemyPrefab));
//    StartCoroutine(Spawn(EnemyShootSpawnRate, EnemyShootPrefab));
//}
//
//private IEnumerator Spawn(float interval, GameObject enemy)
//{
//    Debug.Log(EnemySpawnRate);
//    Debug.Log(EnemyShootSpawnRate);
//    yield return new WaitForSeconds(interval);
//    GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
//    EnemySpawnRate = Random.Range(1, 30f);
//    EnemyShootSpawnRate = Random.Range(1, 30f);
//    StartCoroutine(Spawn(interval, enemy));
//}