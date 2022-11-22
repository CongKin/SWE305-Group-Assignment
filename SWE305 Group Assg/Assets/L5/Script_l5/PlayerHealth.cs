using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    public Events OnPlayerDefeated;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log("Player Damage Taken");
        health -= damageAmount;

        if(health <= 0)
        {
            OnPlayerDefeated?.Invoke();
            Destroy(gameObject, 5);
        }
        
    }
}
