using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float AttackTime;
    public float StartAttackTime;
    public Transform AttackPos;

    public LayerMask EnemyFinder; 
    public float AttackRange = 0.5f; 
    public int Damage = 40;

    void Start()
    {

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AttackTime = StartAttackTime;
            Collider2D[] DamageEnemies = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, EnemyFinder);
            
            foreach(Collider2D Enemy in DamageEnemies)
            {
                Enemy.GetComponent<EnemyMovement>().TakeDamage(Damage);
            }
        }      
        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);
    }
}
