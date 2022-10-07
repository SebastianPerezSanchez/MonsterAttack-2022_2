using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesHealth : MonoBehaviour
{
    //velocidad y vida    
    public int health;
    public float speed;
    //animacion de daño
    public float shineTime;
    public SpriteRenderer[] spr;
    public bool change;
    public Color[] color;
    public float speed_shine;
    public float cronometer;

    public enemiesPatrol enemiesPatrol;
    private Animator animator;

    public bool notHaveHitAnimation;
       [SerializeField] public lifebar lifebar;
    public bool isItBoss;

    public GameObject Bossbar;

    public KillCount killCount;

    public StartScript portalScript;
    void Start()
    {
        animator = GetComponent<Animator>();

          
        if(isItBoss) lifebar.InitializeLifebar(health);

    }

    // Update is called once per frame
    void Update()
    {
        if(health <=0)
        {
            if(enemiesPatrol != null)
            {

            if(enemiesPatrol.checkAnimatorParameters("isWalking")) animator.SetBool("isWalking", false);
            if(enemiesPatrol.checkAnimatorParameters("isRunning")) animator.SetBool("isRunning", false);
            }
            animator.SetTrigger("Death");
            this.enabled = false;
            
            if(enemiesPatrol != null) enemiesPatrol.enabled = false;
            if(isItBoss)
            {
            portalScript.portal.SetActive(true);
            Destroy(Bossbar);
            }
            Destroy(gameObject, 1.2f);

            killCount.increase_kill();
        } 
        HurtAnimation();
     
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Lava")
        {
            health -=  15;
        }
    }

    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log("damage Taken");
        if(isItBoss) lifebar.ChangeActualLife(health); 


    }

    public void HurtAnimation() 
    {
        if (cronometer > 0) 
        {
            cronometer -= 1 * Time.deltaTime;
            spr[1].sprite = spr[0].sprite;
            shineTime += speed_shine * Time.deltaTime;
            if(!notHaveHitAnimation) animator.SetTrigger("Hurt");

            switch (change)
            {
                case true:
                        spr[1].color = color[0];
                        break;
                
                case false:
                        spr[1].color = color[1];
                        break;
            }

            if (shineTime > 1)
            {
                change = !change;
                shineTime = 0;
            }
        } else {
            cronometer = 0;
            spr[1].color = color[0];
        }
    }
}
