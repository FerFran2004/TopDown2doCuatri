using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
    public GameObject EnemyShootHealth;
   
    public float distance;

    void Start()
    {
        
    }

    
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision) //OnTriggerEnter
    {
        //if (collision.collider.gameObject.tag == "EnemiesShoot") 
        //{
        //    collision.gameObject.GetComponent<EnemyShootMovement>().TakeDamage(Damage);
        //    Destroy(gameObject);
        //
        //}

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);

        }
 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemiesShoot")
        {
            collision.gameObject.GetComponent<EnemyShootMovement>().TakeDamage(Damage);
            Debug.Log("Damage");
            Destroy(gameObject);

        }
    }
}
