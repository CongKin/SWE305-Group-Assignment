using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireDamage : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    public PlayerHealth playerHealth;
    public EnemyController enemyHealth;
    bool canTakeDamage = true;

    void Start()
    {

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
            //StartCoroutine (WaitForSeconds());
        }
        if(collision.gameObject.tag == "Enemy")
        {
            enemyHealth.TakeDamage(damage);
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
