using UnityEngine;
using Weapon;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Player {

  public class PlayerModel {
    public static int MAX_WEAPON_CAPACITY = 10;
    public static float MAX_HEALTH_POINT = 100;
    public static float MAX_STAMINA_POINT = 100;
    public enum Party { red, blue };

    private string Name;
    private bool IsRobot;
    private float HealthPoint = MAX_HEALTH_POINT;
    private float Stamina = MAX_STAMINA_POINT;
    private Party PlayerParty;
    private ArrayList Weapons = new ArrayList();

    public PlayerModel(Party party, string name, bool isBot) {
      this.PlayerParty = party;
      this.Name = name;
      this.IsRobot = isBot;
    }

    public bool IsAlive() {
      return this.HealthPoint > 0;
    }

    public string GetName() {
      return this.Name;
    }

    public bool IsBot() {
      return this.IsRobot;
    }

    public float GetHealthPoint() {
      return this.HealthPoint;
    }

    public float GetStamina() {
      return this.Stamina;
    }

    public Party GetParty() {
      return this.PlayerParty;
    }

    public ArrayList GetWeapons() {
      return this.Weapons;
    }

    public void ReceiveDamage(float points) {
      this.HealthPoint = this.HealthPoint - points;
    }

    public void RegainHealth(float points) {
      this.HealthPoint = Math.Min(100, this.HealthPoint + points);
    }

    public void UseStamina(float amount) {
      if (this.Stamina - amount >= 0) {
        this.Stamina = this.Stamina - amount;
      }
    }

    public void RegainStamina(float amount) {
      this.Stamina = Math.Min(100, this.Stamina + amount);
    }

    public bool PickUpWeapon(WeaponModel pickWeapon, int dropWeaponIndex) {
      if (dropWeaponIndex < 0 || dropWeaponIndex >= PlayerModel.MAX_WEAPON_CAPACITY) {
        return false;
      }

      if (this.Weapons.Count >= PlayerModel.MAX_WEAPON_CAPACITY) {
        this.Weapons.Insert(dropWeaponIndex, pickWeapon);
        return true;
      }

      this.Weapons.Add(pickWeapon);
      return true;
    }

    public bool DropWeapon(int dropWeaponIndex) {
      if (dropWeaponIndex < 0 || dropWeaponIndex >= this.Weapons.Count) {
        return false;
      }
      this.Weapons.RemoveAt(dropWeaponIndex);
      return true;
    }

  }
}
