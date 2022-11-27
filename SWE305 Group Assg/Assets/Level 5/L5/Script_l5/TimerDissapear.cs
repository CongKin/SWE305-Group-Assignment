using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDissapear : MonoBehaviour
{
    public float timeToDissapear = 10;
    public float currentTime = 0;
    public bool enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToDissapear)
        {
            currentTime = 0;
            HideObject();
        }
    }

    void HideObject ()
    {
        enabled = false;
        gameObject.SetActive(false);
    }
}
