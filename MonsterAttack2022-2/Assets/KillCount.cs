using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{

    public Text kill_UI;
    public int kill_count;
    void Start() 
    {
    kill_count = 0;   
    kill_UI.text = kill_count.ToString();
    }
     public void increase_kill()
     {
        kill_count++;
        kill_UI.text = kill_count.ToString();
    }
}
