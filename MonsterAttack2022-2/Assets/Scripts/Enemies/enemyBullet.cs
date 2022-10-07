using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{

    private Animator animator;
    public float dieTime;
    void Start()
    {
        animator = GetComponent<Animator>();
        Destroy(gameObject, dieTime);
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(checkAnimatorParameters("Explode"))
        {
            animator.SetTrigger("Explode");
            Destroy(gameObject, 0.5f);
        }
        else
        {
            Destroy(gameObject);
        } 
    }
    
    public bool checkAnimatorParameters(string toCheck) 
    {
        for(int i = 0; i < animator.parameterCount; i++)
        {
            if(animator.parameters[i].name == toCheck)
            {
                return true;
            }
        }

        return false;

    }
    
}
