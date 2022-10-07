using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public BossBehavior bossBehavior;
    public GameObject bossBar;
    public GameObject pillars;

    public static BossUI instance;


    void Start()
    {
        bossBar.SetActive(false);
        pillars.SetActive(false);
    }

     void Update()
    {
        
    }
    
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void BossActivate()
    {
        bossBar.SetActive(true);
        pillars.SetActive(true);
    }
}
