using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootMovement : MonoBehaviour
{
    //Basic Aspects
    public int Health = 150;
    public int BlueTouchDamage = 20;
    public float Speed;
    public int ScoreReward = 20;

    private int currentHealth;
    
    //For movement 
    public float MoveTime;
    private float CurrentMoveTime;
    public float MaxX = 16f;
    public float MinX = -16f;
    public float MaxY = 9f;
    public float MinY = -9f;
    public float RandomDirX;
    public float RandomDirY;
    Vector3 Direction;

    
    private GameObject PlayerBullet;

    //For Players´ Score
    public GameObject PlayerScore;
    
    void Start()
    {
        currentHealth= Health;
        PlayerBullet = GameObject.Find("Bullet");
    }
    public void TakeDamage(int damage)
    {
        Physics.SyncTransforms();
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            PlayerScore = GameObject.FindGameObjectWithTag("Player");
            PlayerScore.GetComponent<Score>().ScoreCount(ScoreReward);
            Destroy(gameObject);

        }
    }

    void Update()
    {
       
        //Changing Direction a certain time period
        if (MoveTime <= 0)
        {
            int NewTime = Random.Range(0, 7);
            MoveTime = NewTime;
        }
        if (MoveTime > 0)
        {
            MoveTime -= Time.deltaTime;
        }


        //Direction Position
        if (CurrentMoveTime <= 0)
        {
            RandomDirX = Random.Range(MinX, MaxX);
            RandomDirY = Random.Range(MinY, MaxY);
            CurrentMoveTime = MoveTime;
        }
        if (CurrentMoveTime > 0)
        {
            Direction = new Vector3(RandomDirX, RandomDirY);
            transform.position += Direction * Speed * Time.deltaTime;
            CurrentMoveTime -= Time.deltaTime;
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

       // if (collision.gameObject.tag == "Wall")
       // {
       //     RandomDirX *= -1;
       //     RandomDirY *= -1;
       // }
        //if (collision.gameObject.tag == "Player")
        //{
        //    gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //}
        //if (collision.gameObject.tag == "PlayerBullet")
        //{
        //    gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //
        //}

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            RandomDirX *= -1;
            RandomDirY *= -1;
        }
    }
}
