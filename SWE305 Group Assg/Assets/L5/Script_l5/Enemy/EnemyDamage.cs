using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    public PlayerHealth playerHealth;
    bool canTakeDamage = true; 
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            animator.Play("Base Layer.enemy_attack", 0, 1f);
            playerHealth.TakeDamage(damage);
            //StartCoroutine (WaitForSeconds());
        }

    }
    
    IEnumerator WaitForSeconds()
    {
        Debug.Log("waited");
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime (3);
        canTakeDamage = true;
    }

}
