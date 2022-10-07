using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifebar : MonoBehaviour
{

    public Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        
    }

    public void ChangeMaxLife(float maxlife)
    {
        slider.maxValue = maxlife;
        Debug.Log(maxlife);


    }

    public void ChangeActualLife(float actualLife)
    {
        slider.value = actualLife;
        Debug.Log(actualLife);

    }

    public void InitializeLifebar(float health)
    {
        Debug.Log(health);
        ChangeMaxLife(health);
        ChangeActualLife(health);
    }
}
