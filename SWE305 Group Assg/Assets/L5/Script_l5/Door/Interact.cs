using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public bool isInRange;
    public static bool isOpen;
    private bool enterAllowed;
    public string sceneToLoad;
    public KeyCode interactKey;
    public KeyCode interactKey2;
    public UnityEvent openDoor;
    public UnityEvent closeDoor;
    public GameObject tips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(interactKey)) //Player presses key
            {
                Debug.Log("Door open");
                openDoor.Invoke();
                isOpen = true;
            }

            if (isOpen && Input.GetKeyDown(interactKey2))
            {   
                if (enterAllowed)
                {
                    Debug.Log("Change Scene");
                    SceneManager.LoadScene(sceneToLoad);
                }
                else
                {
                    Debug.Log("Change Scene fail");
                    tips.SetActive(true);
                }
                    
            }
        }
        else
        {
            if (isOpen)
            {
                closeDoor.Invoke();
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //int key = collision.gameObject.GetComponent<ItemCollector>().getKeyCount();
            isInRange = true;
            Debug.Log("Player now in range");
            if (EnemyManager.getEnemyCount() <= 0)
            {
                Debug.Log("Enter allowed");
                enterAllowed = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player now not in range");
            enterAllowed = false;
        }
    }

}
