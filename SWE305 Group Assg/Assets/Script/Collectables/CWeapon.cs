using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CWeapon : Collectables
{
    public Weapon WeaponToEquip;
 protected override void Pick()
 {
 EquipWeapon();
 }
 private void EquipWeapon()
 {
 if (character != null)
 {
 character.GetComponent<CharacterWeapon>().CurrentWeapon = WeaponToEquip;
 }
 }
}
