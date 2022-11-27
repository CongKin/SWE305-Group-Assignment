using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalTeleport1 : MonoBehaviour
{
    private Transform destination;

    public bool portal1;
    public float distance = 0.2f;

    void Start()
    {
        if(portal1 == false)
        {
            destination = GameObject.FindGameObjectWithTag("Portal 2").GetComponent<Transform>();
        } else
        {
            destination = GameObject.FindGameObjectWithTag("Portal 3").GetComponent<Transform>();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            other.transform.position = new Vector2 (destination.position.x, destination.position.y);
        }
    }
}