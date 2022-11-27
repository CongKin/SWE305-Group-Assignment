using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CHealth : Collectables
{
[SerializeField] private int healthToAdd = 1;

 protected override void Pick()
 {
    AddHealth();
 }
 
 public void AddHealth()
{
 if (character != null)
 {
    character.GetComponent<Health>().AddMaxHealth(healthToAdd);
    character.GetComponent<Health>().GainHealth(healthToAdd);
 }
 }
}