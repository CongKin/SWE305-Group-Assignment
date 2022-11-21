using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTrigger : MonoBehaviour
{
    public string targetTag = "Player";
    public UnityEvent enterEvent, exitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enterEvent?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitEvent?.Invoke();
    }

}
