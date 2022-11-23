using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEnemy : MonoBehaviour
{
    public float timeToBuff = 10;
    public float currentTime = 0;
    public bool enabled;
    EnemyChase chaseSpeed;

    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToBuff)
        {
            currentTime = 0;
            IncreaseSpeed ();
        }
    }

    void IncreaseSpeed ()
    {
        enabled = true;
        if (chaseSpeed.speed < 10)
            chaseSpeed.speed += 1;
        Vector2 scale = transform.localScale;
        if (scale.x > 0.1 && scale.y > 0.1)
        {
            scale.x -= 0.1f;
            scale.y -= 0.1f;
            transform.localScale = scale;
        }
    }
}
