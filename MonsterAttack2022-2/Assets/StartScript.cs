using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
  public GameObject portal;
  void Start() 
  {
    portal.SetActive(false);
  }
  private void OnTriggerEnter2D(Collider2D collision){
    if(collision.gameObject.tag == "Player"){
        SceneManager.LoadScene(2);
    }
  }
}
