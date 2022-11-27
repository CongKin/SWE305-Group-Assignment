using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireDamage : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    public Health playerHealth;
    public EnemyController enemyHealth;
    bool canTakeDamage = true;
    public List<int> burnTickTimers = new List<int>();

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
        if(collision.gameObject.tag == "Enemy")
        {
            enemyHealth.TakeDamage(damage);
        }

    }

}
