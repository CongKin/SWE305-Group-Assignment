using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    public static Level instance;

    uint numDestructables = 0;
    bool startNextLevel = false;
    float nextLevelTimer = 10;

    private string sceneToLoad;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startNextLevel)
        {
            if (nextLevelTimer<=0)
            {
                sceneToLoad = "Level 2";
                SceneManager.LoadScene(sceneToLoad); 
            }
            else
            {
                nextLevelTimer -= Time.deltaTime;
            }
        }
    }


    public void ResetLevel()
    {
        foreach(Bullet b in GameObject.FindObjectsOfType<Bullet>())
        {
            Destroy (b.gameObject);
        }
        numDestructables = 0;
        sceneToLoad = "Level 1";
        SceneManager.LoadScene(sceneToLoad);  
    }
    public void AddDestructable()
    {
        numDestructables++;
    }

    public void RemoveDestructable()
    {
        numDestructables--;

        if(numDestructables == 0)
        {
            startNextLevel = true;
        }
    }
}
