using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWeapon : MonoBehaviour
{
    public Health playerHealth;

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
