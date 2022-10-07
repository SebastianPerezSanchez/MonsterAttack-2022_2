using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossActivate : MonoBehaviour
{
    public HeroMovement hero;
    public GameObject BossGenerate;
    public num_enemies num_Enemies;
    public KillCount killCount;
    public Text needToKill;

    private void Start() 
    {
        BossGenerate.SetActive(false);
        needToKill.text = "";
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
            if(other.CompareTag("Player"))
            {
                if(killCount.kill_count == num_Enemies.enemies)
                {
                    BossUI.instance.BossActivate();
                    StartCoroutine(WaitForBoss());
                    needToKill.text = "";

                }
                else
                {
                    needToKill.text = "Se necesita matar a los enemigos";
                }
            }
    }
    IEnumerator WaitForBoss()
    {
        BossGenerate.SetActive(true);
        hero.enabled = false;
        yield return new WaitForSeconds(3);
        hero.enabled = true;
        Destroy(gameObject);
    }

}
