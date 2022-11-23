using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MissionShow: MonoBehaviour
{
    public GameObject MissionBar;
    private float showTimer=3;
    // Start is called before the first frame update
    void Awake()
    {
        MissionBar.SetActive(true);
    }
 
    // Update is called once per frame
    void Update()
    {
        showTimer -= Time.deltaTime;
        if (showTimer < 0)
        {
            MissionBar.SetActive(false);
        }
    }
}

