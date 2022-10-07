using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    private bool canShoot, canTP;
    public Transform playerTransform;
    public Transform[] transforms, shootTransform;

    private float distToPlayer;
    public float range, timeBtwShoots, shootSpeed, timeToTP;
    public Rigidbody2D rb;
    public float walkSpeed;
    public GameObject bullet;

    public Vector2 moveDirection;


    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
        canShoot = true;
        canTP = true;

    }

    // Update is called once per frame
    void Update()
    {

        distToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if(distToPlayer <= range)
        {
                if(playerTransform.position.x >transform.position.x && transform.localScale.x < 0
                    || playerTransform.position.x < transform.position.x && transform.localScale.x >0)
                    {
                        Flip();
                    }

            rb.velocity = Vector2.zero;

            if(canShoot) StartCoroutine(Shoot());
            if(canTP) StartCoroutine(Teleport());
            
       
        }
     
    }


    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        

    }

    IEnumerator Shoot()
    {
        canShoot = false;

        yield return new WaitForSeconds(timeBtwShoots);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1);
        GameObject newBullet = Instantiate(bullet, shootTransform[0].position, Quaternion.identity);
        GameObject newBullet1 = Instantiate(bullet, shootTransform[1].position, Quaternion.identity);
        GameObject newBullet2 = Instantiate(bullet, shootTransform[2].position, Quaternion.identity);


        Vector2 Direction = playerTransform.position - transform.position;
        moveDirection = (playerTransform.transform.position - transform.position).normalized * walkSpeed;
        newBullet.transform.up = -Direction;
        newBullet1.transform.up = -Direction;
        newBullet2.transform.up = -Direction;

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x, moveDirection.y);
        newBullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x, moveDirection.y);
        newBullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x, moveDirection.y);


        canShoot = true;
    }

    IEnumerator Teleport()
    {
        canTP = false;
        yield return new WaitForSeconds(timeToTP);
        animator.SetTrigger("Teleport");
        yield return new WaitForSeconds(1);
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;

        canTP = true;
    }



}
