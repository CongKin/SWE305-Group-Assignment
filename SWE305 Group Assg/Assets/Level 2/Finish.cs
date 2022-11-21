using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  private void OnTriggerEnter2D(Collider2D collision)
{
   if(collision.gameObject.name=="Player")
{   
    finishLevel2();
}
}

 private void finishLevel2()
{
 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
}
}