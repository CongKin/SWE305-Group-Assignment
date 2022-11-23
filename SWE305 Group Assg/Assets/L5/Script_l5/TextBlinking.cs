using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBlinking : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public float BlinkFadeInTime = 0.5f;
    public float BlinkStayTime = 0.8f;
    public float BlinkFadeOutTime = 0.7f;
    private float timeChecker = 0;
    private Color color;

    void Start()
    {
        color = text.color;
    }

    void Update()
    {
        timeChecker += Time.deltaTime;
        if (timeChecker < BlinkFadeInTime)
        {
            text.color = new Color(color.r, color.g, color.b, timeChecker / BlinkFadeInTime);
        } 
        else if (timeChecker < BlinkFadeInTime + BlinkStayTime)
        {
            text.color = new Color(color.r, color.g, color.b, 1);
        } 
        else if (timeChecker < BlinkFadeInTime + BlinkStayTime + BlinkFadeOutTime)
        {
            text.color = new Color(color.r, color.g, color.b, 1 - (timeChecker - (BlinkFadeInTime + BlinkStayTime))/BlinkFadeOutTime);
        }
        else
        {
            timeChecker = 0;
        }

    }
}
