using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform playerTarget;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(playerTarget.position.x, playerTarget.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed*Time.deltaTime);
    }
}
