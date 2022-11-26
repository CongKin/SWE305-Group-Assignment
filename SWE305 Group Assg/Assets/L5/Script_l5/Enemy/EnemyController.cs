using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    public UnityEvent onEnemyHit;
    float Timer = 2;
    bool canBeDefeated = false;

    void Start () {
        EnemyManager.Register(gameObject.GetInstanceID(), this);
        Debug.Log("Enemy registered");
        health = maxHealth;
        UIManager.Instance.UpdateEnemyHealth(health, maxHealth);
    }


    public void TakeDamage(float damageAmount)
    {
        onEnemyHit?.Invoke();
        Debug.Log("Damage Taken");
        health -= damageAmount;
        UIManager.Instance.UpdateEnemyHealth(health, maxHealth);

        if (health <= 0)
        {
            Destroy(gameObject, 2);
            EnemyManager.HandleEnemyDefeated(gameObject.GetInstanceID(), this);
        }
    }
}
