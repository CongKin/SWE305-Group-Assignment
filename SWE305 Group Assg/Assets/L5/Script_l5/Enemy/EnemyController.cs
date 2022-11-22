using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    public UnityEvent OnEnemyKilled;
    public KeyCode key;

    void Start () {
        EnemyManager.Register(gameObject.GetInstanceID(), this);
        Debug.Log("Enemy registered");
        health = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown (key))
        {
            TakeDamage (1f);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log("Damage Taken");
        health -= damageAmount;

        if(health <= 0)
        {
            Destroy(gameObject);
            EnemyManager.HandleEnemyDefeated(gameObject.GetInstanceID(), this);
        }
        
    }
}
