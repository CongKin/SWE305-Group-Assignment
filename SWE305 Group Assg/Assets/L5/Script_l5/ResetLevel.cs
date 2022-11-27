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
            gameOverText.SetActive(true);
            if (Input.GetKeyDown(reset))
            {
                sceneToLoad = "Final Level";
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
