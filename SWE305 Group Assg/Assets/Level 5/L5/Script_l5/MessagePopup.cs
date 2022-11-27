using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePopup : MonoBehaviour
{
    public GameObject Message;
    public GameObject Message2;
    
    void Update ()
    {
        if(Interact.isOpen)
        {
            Message.SetActive(false);
            Message2.SetActive(true);
        }
    }

    private void OnTriggerStay2D (Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Message.SetActive(true);
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Message.SetActive(false);
            Message2.SetActive(false);
        }
    }
}
