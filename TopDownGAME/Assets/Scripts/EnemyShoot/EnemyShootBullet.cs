using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShootBullet : MonoBehaviour
{
    public GameObject Player;
    public float Force;
    public int Damage;

    private Rigidbody2D EnemySBullet_rg;
    
    void Start()
    {
        EnemySBullet_rg= GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        
        Vector3 direction = Player.transform.position - transform.position; //Donde disparar en base a player position
        EnemySBullet_rg.velocity = new Vector2(direction.x, direction.y).normalized * Force;
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().RecieveDamage(Damage);
            Destroy(gameObject);
        }

    }
}
