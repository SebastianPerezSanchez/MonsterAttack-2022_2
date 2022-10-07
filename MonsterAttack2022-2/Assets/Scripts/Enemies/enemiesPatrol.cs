using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesPatrol : MonoBehaviour
{
    private bool canShoot;

    public bool mustTurn;
    public float walkSpeed, range, timeBtwShoots, shootSpeed;
    public bool isGonnaChase, isGonnaShoot;
    private float distToPlayer;
    public bool mustPatrol;
    public Rigidbody2D rb;
    public Transform floorCheckPosition;
    public LayerMask floorLayer;
    public Collider2D bodyCollider;
    public Transform playerTransform, shootTransform;
    public GameObject bullet;
    public bool isOnRange;

    public float KBforce;
    public float KBcounter;
    public float KBtotalTime;
    public bool knockFromRight;
    
    private Animator animator;
    void Start()
    {
        mustPatrol = true;
        isOnRange = false;
        animator = GetComponent<Animator>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(checkAnimatorParameters("isWalking")) animator.SetBool("isWalking", mustPatrol);
        if(checkAnimatorParameters("isRunning")) animator.SetBool("isRunning", isOnRange);

        if(mustPatrol || bodyCollider.IsTouchingLayers(floorLayer)){
            Patrol();
        }
        
        distToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if(distToPlayer <= range) 
        {
            mustPatrol = false;
                if(playerTransform.position.x >transform.position.x && transform.localScale.x < 0
                    || playerTransform.position.x < transform.position.x && transform.localScale.x >0)
                    {
                        Flip();
                    }
            isOnRange = true;
            if(isGonnaChase) rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime * 1.2f, rb.velocity.y);
            if(isGonnaShoot)
            {
                rb.velocity = Vector2.zero;
                if(canShoot) StartCoroutine(Shoot());
            }      
        }
        else
        {
            mustPatrol = true;
            isOnRange = false;
        }
        
    
    }
    
    private void FixedUpdate() {

        if(KBcounter <= 0) 
        {
            if(mustPatrol){
                mustTurn = !Physics2D.OverlapCircle(floorCheckPosition.position, 0.1f, floorLayer);
            }       
        }
        else
        {
            if (knockFromRight) rb.velocity = new Vector2(-KBforce, KBforce);
            if (knockFromRight == false) rb.velocity = new Vector2(KBforce, KBforce);

            KBcounter -= Time.deltaTime;
        }
       

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {

            Flip();
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

    void Patrol()
    {
        if(mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
        
    }


    void Flip()
    {
        mustPatrol = false; 
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true; 
    }


    IEnumerator Shoot()
    {
        canShoot = false;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(timeBtwShoots);

        GameObject newBullet = Instantiate(bullet, shootTransform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
    
        canShoot = true;
    }

}




