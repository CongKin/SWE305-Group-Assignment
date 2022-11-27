using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIDetector : MonoBehaviour
{
    [field: SerializeField]
    public bool isInArea { get; private set; }
    public Transform Player { get; private set; }

    [SerializeField] private string detectionTag = "Player";
    public UnityEvent enterEvent, exitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectionTag))
        {
            isInArea = true;
            Debug.Log("Player detected");
            Player = collision.gameObject.transform;
            enterEvent.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(detectionTag))
        {
            isInArea = false;
            Debug.Log("Player out of range");
            Player = null;
            exitEvent.Invoke();
        }
    }
}
