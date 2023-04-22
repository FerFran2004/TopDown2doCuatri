using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootAttack : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletPos;
    [SerializeField] private float FireRate;
    public float FireRateMin;
    public float FireRateMax;
    public GameObject Player;
    private float ReadyToFire;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        FireRate = Random.Range(FireRateMin, FireRateMax);
    }

    
    void Update()
    {
        if (Player != null)
        {
            if (ReadyToFire > FireRate)
            {
                Instantiate(Bullet, BulletPos.position, Quaternion.identity);
                ReadyToFire = 0;
                FireRate = Random.Range(FireRateMin, FireRateMax);
            }
            if (ReadyToFire < FireRate)
            {
                ReadyToFire += Time.deltaTime;
            }
        }
        else
        {

        }


    }
    
    
}
