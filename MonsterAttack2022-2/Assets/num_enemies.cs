using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class num_enemies : MonoBehaviour
{
    public int enemies;
    // Start is called before the first frame update
    public Text enemies_UI;
    void Start()
    {
      enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;    
      enemies_UI.text = enemies.ToString();   
    }

}
