using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSkull : MonoBehaviour
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


    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Running", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <=0) Destroy(gameObject);
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        HurtAnimation(); 

    }

    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log("damage Taken");

    }

    public void HurtAnimation() 
    {
        if (cronometer > 0) 
        {
            cronometer -= 1 * Time.deltaTime;
            spr[1].sprite = spr[0].sprite;
            shineTime += speed_shine * Time.deltaTime;

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
