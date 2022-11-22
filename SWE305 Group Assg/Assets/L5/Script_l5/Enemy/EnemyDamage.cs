using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    public PlayerHealth playerHealth;
    bool canTakeDamage = true; 

    private void OnCollisionStay2D (Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player" && canTakeDamage)
        {
            playerHealth.TakeDamage(damage);
            StartCoroutine (WaitForSeconds());
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
