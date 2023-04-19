using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int angleOffset;
    public int Health = 100;
    public Text HealthText;
    public int CurrentHealth;
    public HealthBar healthBar;
    public Rigidbody2D rbPlayer;
    public Gun weapon;

    public GameObject RedEnemy;
    public GameObject ShootEnemy;
    public GameObject EnemyShootBullet;


    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        CurrentHealth = Health;
        healthBar.SetMaxHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {
        //Position to PlayerMovement
        GameObject Position = GameObject.Find("Player");
        transform.position = Position.transform.position;
        
        
        //Look at Mouse
        var MouseDir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var Angle = Mathf.Atan2(MouseDir.x, MouseDir.y) * Mathf.Rad2Deg * angleOffset;
        transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);

        HealthText.text = CurrentHealth.ToString() + "%";
        if (Input.GetKeyDown(KeyCode.K))
        {
            CurrentHealth = 0;
        }

        if (CurrentHealth == 0)
        {
            Destroy(gameObject);
        }




    }
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("PARED"); //Lo detecta, pero no se detiene 
            
        }


        if (collision.gameObject.tag == "EnemiesShoot")
        {
            ShootEnemy = GameObject.Find("EnemyShoot");
            int BlueDamage = ShootEnemy.GetComponent<EnemyShootMovement>().BlueTouchDamage;
            CurrentHealth -= BlueDamage;
            healthBar.HealthDisplay(CurrentHealth);
            if (CurrentHealth <= 0) // Feature de last stande?: (Health < 0) Hace que tenga 0 pero aun asi se pueda mover, pero se muere al siguente golpe
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Enemies")
        {
            RedEnemy = GameObject.Find("Enemy");
            int RedDamage = RedEnemy.GetComponent<EnemyMovement>().TouchDamage;
            CurrentHealth -= RedDamage;
            healthBar.HealthDisplay(CurrentHealth);
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);

            }

        }
        if (collision.gameObject.tag == "EnemyShootBullet")
        {
            EnemyShootBullet = GameObject.FindWithTag("EnemyShootBullet");
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;    //Eliminate EnemyShootBullet aplied Force by reseting the body´s state
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;   //Eliminate EnemyShootBullet aplied Force by reseting the body´s state
            int EnemyShootBulletDamage = EnemyShootBullet.GetComponent<EnemyShootBullet>().Damage;
            CurrentHealth -= EnemyShootBulletDamage;
            healthBar.HealthDisplay(CurrentHealth);
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);

            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Debug.Log("ENEMIGO ROJO");

        }
        //if (collision.gameObject.tag == "EnemiesShoot")
        //{
        //    ShootEnemy = GameObject.Find("EnemyShoot");
        //    int BlueDamage = ShootEnemy.GetComponent<EnemyShootMovement>().BlueTouchDamage;
        //    CurrentHealth -= BlueDamage;
        //    healthBar.HealthDisplay(CurrentHealth);
        //    if (CurrentHealth <= 0) // Feature de last stande?: (Health < 0) Hace que tenga 0 pero aun asi se pueda mover, pero se muere al siguente golpe
        //    {
        //        Destroy(gameObject);
        //    }
        //}
        if (collision.gameObject.tag == "EnemyShootBullet")
        {
            EnemyShootBullet = GameObject.FindWithTag("EnemyShootBullet");
            int EnemyShootBulletDamage = EnemyShootBullet.GetComponent<EnemyShootBullet>().Damage;
            CurrentHealth -= EnemyShootBulletDamage;
            healthBar.HealthDisplay(CurrentHealth);
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);

            }

        }

    }









}

