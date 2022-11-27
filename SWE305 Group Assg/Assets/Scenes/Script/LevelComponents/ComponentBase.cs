using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentBase : MonoBehaviour
{
    [Header("Sprite")]
    [SerializeField] private Sprite brokenSprite1;
    [SerializeField] private Sprite brokenSprite2;
    [SerializeField] private Sprite damagedSprite;

    [Header("Settings")]
    [SerializeField] private int damage = 1;
    [SerializeField] private bool isDamageable;
        
    private Health health;  
    private SpriteRenderer spriteRenderer; 
    private Collider2D collider2D;

    private void Start()
    {
        health = GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet1"))
        {
            damage = 2;
            TakeDamage();
        }

        if (other.CompareTag("Bullet2"))
        {
            damage = 5;
            TakeDamage();
        }

        if (other.CompareTag("Bullet3"))
        {
            damage = 10;
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        health.TakeDamage(damage);

        if (health.CurrentHealth > health.MaxHealth/2)
        {
            spriteRenderer.sprite = brokenSprite1;
        }

        if (health.CurrentHealth > 0)
        {
            spriteRenderer.sprite = brokenSprite2;
        }

        if(health.CurrentHealth <= 0)
        {
            spriteRenderer.sprite = damagedSprite;
            collider2D.enabled = false;
        }
    }
}
