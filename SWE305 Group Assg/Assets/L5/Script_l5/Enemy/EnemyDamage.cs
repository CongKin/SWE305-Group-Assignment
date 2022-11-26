using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    [SerializeField] float playerDamage = 1f;
    public Health playerHealth;
    public EnemyController enemyHealth;
    bool canTakeDamage = true; 
    private Animator animator;
    public ReturnToPool resetProjectile;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            animator.Play("Base Layer.enemy_attack", 0, 1f);
            StartCoroutine (WaitForSeconds());
            playerHealth.TakeDamage(damage);
        }   
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Bullet1")
        {
            enemyHealth.TakeDamage(damage);
            resetProjectile.Return();
        }
        
        if(collision.gameObject.tag == "Bullet2")
        {
            enemyHealth.TakeDamage(damage);
            resetProjectile.Return();
        }

        if(collision.gameObject.tag == "Bullet3")
        {
            enemyHealth.TakeDamage(damage);
            resetProjectile.Return();
        }
    }


    
    IEnumerator WaitForSeconds()
    {
        Debug.Log("waited");
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime (2);
        canTakeDamage = true;
    }

}
