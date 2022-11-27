using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    public GameObject gameOverText;
    private string sceneToLoad;
    public Health playerHealth;
    public KeyCode reset;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        gameOverText = GameObject.FindGameObjectWithTag("GameOver");


    }


    void Update()
    {
        if(playerHealth.CurrentHealth <= 0)
        {
            Debug.Log("Player die");
            //gameOverText.SetActive(true);
            Debug.Log("Game Over");
            if (Input.GetKeyDown(reset))
            {
                playerHealth.Revive();

                sceneToLoad = "Level 5";
                SceneManager.LoadScene(sceneToLoad);

                
            }
        }
    }
}
