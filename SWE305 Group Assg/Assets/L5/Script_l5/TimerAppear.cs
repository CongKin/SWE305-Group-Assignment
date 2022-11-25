using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAppear : MonoBehaviour
{
    public GameObject gameObject;
    public float timeToAppear = 10;
    public float currentTime = 0;
    public bool enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToAppear)
        {
            RevealObject();
        }
    }

    void RevealObject ()
    {
        enabled = false;
        gameObject.SetActive(true);
    }
}
