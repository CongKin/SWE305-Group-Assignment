using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;	

public class UIManager : Singleton<UIManager>
{
    [Header("Settings")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image shieldBar;
    [SerializeField] private TextMeshProUGUI currentHealthTMP;
	[SerializeField] private TextMeshProUGUI currentShieldTMP;
    [SerializeField] private Image enemyHealthBar;
    [SerializeField] private TextMeshProUGUI currentEnemyHealthTMP;

    [Header("Weapon")]
    [SerializeField] private TextMeshProUGUI currentAmmoTMP;
    [SerializeField] private Image weaponImage;

    private float playerCurrentHealth;
    private float playerMaxHealth;
    private float playerMaxShield;
	private float playerCurrentShield;
    private bool isPlayer;
    private float enemyCurrentHealth;
    private float enemyMaxHealth;

    private int playerCurrentAmmo;
    private int playerMaxAmmo;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().UpdateCharacterHealth();
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterWeapon>().UpdateWeapon();
    }

    private void Update()
    {
        InternalUpdate();
    }
    
    public void UpdateHealth(float currentHealth, float maxHealth, float currentShield, float maxShield, bool isThisMyPlayer)
    { 
        playerCurrentHealth = currentHealth;
        playerMaxHealth = maxHealth; 
        playerCurrentShield = currentShield;
        playerMaxShield = maxShield;       
        isPlayer = isThisMyPlayer;  
	}

    public void UpdateWeaponSprite(Sprite weaponSprite)
 {
 weaponImage.sprite = weaponSprite;
 weaponImage.SetNativeSize();
 }


    public void UpdateEnemyHealth(float currentHealth, float maxHealth)
    { 
        enemyCurrentHealth = currentHealth;
        enemyMaxHealth = maxHealth;       
	}

    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        playerCurrentAmmo = currentAmmo;
        playerMaxAmmo = maxAmmo;
    }

    private void InternalUpdate()
    {        
        if (isPlayer)
        {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerCurrentHealth / playerMaxHealth, 10f * Time.deltaTime);
            currentHealthTMP.text = playerCurrentHealth.ToString() + "/" + playerMaxHealth.ToString(); 

            shieldBar.fillAmount = Mathf.Lerp(shieldBar.fillAmount, playerCurrentShield / playerMaxShield, 10f * Time.deltaTime);
            currentShieldTMP.text = playerCurrentShield.ToString() + "/" + playerMaxShield.ToString();
        } 

        // Update Ammo
        currentAmmoTMP.text = playerCurrentAmmo.ToString() + " / " + playerMaxAmmo.ToString();   

        enemyHealthBar.fillAmount = Mathf.Lerp(enemyHealthBar.fillAmount, enemyCurrentHealth / enemyMaxHealth, 10f * Time.deltaTime);
        currentEnemyHealthTMP.text = enemyCurrentHealth.ToString() + "/" + enemyMaxHealth.ToString();

            
    }
}