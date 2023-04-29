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
    public Gun weapon;

    [SerializeField] private GameObject RedEnemy;
    [SerializeField] private GameObject ShootEnemy;
    [SerializeField] private GameObject EnemyShootBullet;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = Health;
        healthBar.SetMaxHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {
        //Position to Parent
        GameObject Position = GameObject.Find("Player");
        transform.position = Position.transform.position;

        //Look at Mouse
        Vector3 mousePos = Input.mousePosition; 
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);  

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y); 
        transform.up = direction; 

        if (Input.GetKeyDown(KeyCode.K))
        {
            CurrentHealth -= 999;
        }

        if (CurrentHealth <= 0)
        {
            gameObject.GetComponent<Score>().FinalCombo();
            CurrentHealth = 0;
            Destroy(gameObject);
        }

        HealthText.text = CurrentHealth.ToString() + "%";

    }

    private void OnCollisionEnter2D(Collision2D collision)

    {

        if (collision.gameObject.tag == "EnemiesShoot")
        {
            int BlueDamage = collision.gameObject.GetComponent<EnemyShootMovement>().BlueTouchDamage;
            RecieveDamage(BlueDamage);   
        }

        if (collision.gameObject.tag == "Enemies")
        {
            int RedDamage = collision.gameObject.GetComponent<EnemyMovement>().TouchDamage;
            RecieveDamage(RedDamage);
        }

    }

    public void RecieveDamage(int dmg)
    { 
        CurrentHealth -= dmg;
        healthBar.HealthDisplay(CurrentHealth);
        gameObject.GetComponent<Score>().ResetCombo();

    }

}

