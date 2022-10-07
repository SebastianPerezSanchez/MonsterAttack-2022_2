using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HeroHealth : MonoBehaviour
{

    private Animator animator;
    public HeroMovement heroMovement;
    public HeroAttack heroAttack;
   [SerializeField] public lifebar lifebar;
    
    public float health;

    private float maxlife;
    
    

    void Start() 
    {
        animator = GetComponent<Animator>();
        maxlife = health;
        lifebar.InitializeLifebar(health);
    }

    [System.Obsolete]
    void Update() 
    {
        if(health <= 0)
        {
            animator.SetTrigger("Death");
            heroMovement.enabled = false;
            heroAttack.enabled = false;

            if(Input.GetKey(KeyCode.Space)) SceneManager.LoadScene("SampleScene");

        }    
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.name.Contains("fireBall"))
        {
            heroMovement.KBcounter = heroMovement.KBtotalTime;
            //Check if player was hit from right or left 
            if(other.transform.position.x <= transform.position.x) heroMovement.knockFromRight = false;
            if(other.transform.position.x > transform.position.x) heroMovement.knockFromRight = true;
            animator.SetTrigger("Hurt");
            health -= 3;
            lifebar.ChangeActualLife(health); 
        }
         if(other.gameObject.name.Contains("ghostBall"))
        {
            heroMovement.KBcounter = heroMovement.KBtotalTime;
            //Check if player was hit from right or left 
            if(other.transform.position.x <= transform.position.x) heroMovement.knockFromRight = false;
            if(other.transform.position.x > transform.position.x) heroMovement.knockFromRight = true;
            animator.SetTrigger("Hurt");
            health -= 5;
            lifebar.ChangeActualLife(health); 
        }
        
         
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Traps")
        {
             heroMovement.KBcounter = heroMovement.KBtotalTime;
            //Check if player was hit from right or left 
            if(other.transform.position.x <= transform.position.x) heroMovement.knockFromRight = false;
            if(other.transform.position.x > transform.position.x) heroMovement.knockFromRight = true;
            animator.SetTrigger("Hurt");
            health -= 1;
            lifebar.ChangeActualLife(health);
        }
        
        if(other.gameObject.tag == "Lava")
        {
             heroMovement.KBcounter = heroMovement.KBtotalTime;
            //Check if player was hit from right or left 
            if(other.transform.position.x <= transform.position.x) heroMovement.knockFromRight = false;
            if(other.transform.position.x > transform.position.x) heroMovement.knockFromRight = true;
            animator.SetTrigger("Hurt");
            health -= 15;
            lifebar.ChangeActualLife(health);
        }

        if(other.gameObject.tag == "Potions")
        {
            Addhealth();
            Destroy(other.gameObject);
        }
    }
    public void takingDamage(int damage)
    {
        lifebar.ChangeActualLife(health);
        animator.SetTrigger("Hurt");
        health-=damage;
        
    }

    public void Addhealth()
    {
        if(health < maxlife)
        {
            health += 20;
            lifebar.ChangeActualLife(health);

        }

        if(health > maxlife)
        {
            health = maxlife;
            lifebar.ChangeActualLife(health);

        }
    }



}
