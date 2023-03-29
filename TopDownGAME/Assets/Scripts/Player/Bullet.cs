using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
    public GameObject EnemyShootHealth;
   // public LayerMask ShootEnemy;
    public float distance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "EnemiesShoot") 
        {
            collision.gameObject.GetComponent<EnemyShootMovement>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);

        }
 
    }
}
