using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBodyDamage : MonoBehaviour
{
    private Animator animator;
    public int damage;
    public HeroHealth heroHealth;
    public HeroMovement heroMovement;
    private void OnCollisionEnter2D(Collision2D collision) {
        if( collision.gameObject.tag == "Player")
        {
            heroMovement.KBcounter = heroMovement.KBtotalTime;
            //Check if player was hit from right or left 
            if(collision.transform.position.x <= transform.position.x) heroMovement.knockFromRight = true;
            if(collision.transform.position.x > transform.position.x) heroMovement.knockFromRight = false;
        
            heroHealth.takingDamage(damage);
        }
    }

}
