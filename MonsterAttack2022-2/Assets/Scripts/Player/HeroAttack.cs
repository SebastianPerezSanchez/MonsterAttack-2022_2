using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public float startTimeBtwAttack;
    public Transform attackPosition;
    public float attackRange;
    public LayerMask isItEnemy;
    public int damage;
    private Animator animator;
    private float timeBtwAttack;
    public enemiesPatrol enemiesPatrol;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0){
            if (Input.GetKey(KeyCode.Z))
            {
                Attack();
            }
            timeBtwAttack = startTimeBtwAttack;
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }

    private void Attack()
    {
            animator.SetTrigger("Attack");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, isItEnemy);
                for(int i = 0; i < enemiesToDamage.Length; i++){

                    enemiesPatrol.KBcounter = enemiesPatrol.KBtotalTime;
                    if(attackPosition.transform.position.x <= transform.position.x) enemiesPatrol.knockFromRight = true;
                    if(attackPosition.transform.position.x > transform.position.x) enemiesPatrol.knockFromRight = false;


                    enemiesToDamage[i].GetComponent<enemiesHealth>().TakeDamage(damage);
                    enemiesToDamage[i].GetComponent<enemiesHealth>().cronometer = 0.5f;
                    
                

                    }
    }
}
