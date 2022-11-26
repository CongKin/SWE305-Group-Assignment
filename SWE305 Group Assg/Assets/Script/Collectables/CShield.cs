using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CShield : Collectables
{
[SerializeField] private int shieldToAdd = 1;

 protected override void Pick()
 {
    AddShield();
 }
 
 public void AddShield()
{
 if (character != null)
 {
    character.GetComponent<Health>().AddMaxShield(shieldToAdd);
    character.GetComponent<Health>().GainShield(shieldToAdd);
 }
 }
}