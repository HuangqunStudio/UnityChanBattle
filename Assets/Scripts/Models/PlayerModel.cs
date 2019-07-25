using Weapon;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Player {

  public class PlayerModel {
    public static int MAX_WEAPON_CAPACITY = 10;
    public static float MAX_HEALTH_POINT = 100;
    public static float MAX_STAMINA_POINT = 100;
    public enum Party { Red, Blue };

    private string name;
    private string playerId;
    private bool isRobot;
    private float healthPoint = MAX_HEALTH_POINT;
    private float stamina = MAX_STAMINA_POINT;
    private Party playerParty;
    private List<WeaponModel> weapons = new List<WeaponModel>();

    public string Name {
      get {
        return this.name;
      }
    }

    public string PlayerId {
      get {
        return this.playerId;
      }
    }

    public bool IsRobot {
      get {
        return this.isRobot;
      }
    }

    public bool IsAlive {
      get {
        return this.healthPoint > 0;
      }
    }

    public float HealthPoint {
      get {
        return this.healthPoint;
      }
    }

    public float Stamina {
      get {
        return this.stamina;
      }
    }

    public Party Party {
      get {
        return this.party;
      }
    }

    public List<WeaponModel> Weapons {
      get {
        return this.weapons;
      }
    }

    public PlayerModel(Party party, string name, bool isBot) {
      this.playerParty = party;
      this.name = name;
      this.isRobot = isBot;
    }

    public void ReceiveDamage(float points) {
      this.healthPoint = Math.Max(0, this.healthPoint - points);
    }

    public void RegainHealth(float points) {
      this.healthPoint = Math.Min(MAX_HEALTH_POINT, this.healthPoint + points);
    }

    public void UseStamina(float amount) {
      if (this.stamina - amount >= 0) {
        this.stamina = this.stamina - amount;
      }
    }

    public void RegainStamina(float amount) {
      this.stamina = Math.Min(MAX_STAMINA_POINT, this.stamina + amount);
    }

    public bool PickUpWeapon(WeaponModel pickWeapon, int dropWeaponIndex) {
      if (dropWeaponIndex < 0 || dropWeaponIndex >= MAX_WEAPON_CAPACITY) {
        return false;
      }

      if (this.weapons.Count >= MAX_WEAPON_CAPACITY) {
        this.weapons.Insert(dropWeaponIndex, pickWeapon);
        return true;
      }

      this.weapons.Add(pickWeapon);
      return true;
    }

    public bool DropWeapon(int dropWeaponIndex) {
      if (dropWeaponIndex < 0 || dropWeaponIndex >= this.Weapons.Count) {
        return false;
      }
      this.weapons.RemoveAt(dropWeaponIndex);
      return true;
    }

  }
}
