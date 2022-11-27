using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private int nextScene;

    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(ItemCollector.keys>=3){
            Debug.Log("Change Scene");
            SceneManager.LoadScene(nextScene);
        }
    }
}
