using UnityEngine;
using WeaponModel;

public class PlayerModel {

  public static int MAX_WEAPON_CAPACITY = 10;
  public static float MAX_HEALTH_POINT = 100;
  public static float MAX_STAMINA_POINT = 100;
  public static enum Party { red, blue };

  private string Name;
  private boolean IsBot;
  private float HealthPoint = PlayerModel.MAX_HEALTH_POINT;
  private float Stamina = PlayerModel.MAX_STAMINA_POINT;
  private Party Party;
  private ArrayList<WeaponModel> Weapons = new ArrayList<WeaponModel>();

  public PlayerModel(Party party, string name, boolean isBot) {
    this.Party = party;
    this.Name = name;
    this.IsBot = isBot;
  }

  public boolean IsAlive() {
    return this.HealthPoint > 0;
  }

  public string GetName() {
    return this.Name;
  }

  public boolean IsBot() {
    return this.IsBot;
  }

  public float GetHealthPoint() {
    return this.HealthPoint;
  }

  public float GetStamina() {
    return this.Stamina;
  }

  public Party GetParty() {
    return this.Party;
  }

  public WeaponModel[] GetWeapons() {
    return this.Weapons;
  }

  public void ReceiveDamage(float points) {
    this.HealthPoint = this.healthPoint - points;
  }

  public void RegainHealth(float points) {
    this.HealthPoint = min(100, this.HealthPoint + points);
  }

  public void UseStamina(float amount) {
    if (this.Stamina - this.amount >= 0) {
      this.Stamina = this.Stamina - amount;
    }
  }

  public void RegainStamina(float amount) {
    this.Stamina = min(100, this.Stamina + amount);
  }

  public boolean PickUpWeapon(WeaponModel pickWeapon, int dropWeaponIndex) {
    if (dropWeaponIndex < 0 || dropWeaponIndex >= WeaponModel.MAX_WEAPON_CAPACITY) {
      return false;
    }

    if (this.Weapons.Count >= WeaponModel.MAX_WEAPON_CAPACITY) {
      this.Weapons.Insert(dropWeaponIndex, pickWeapon);
      return true;
    }

    this.Weapons.Add(weapon);
  }

  public boolean DropWeapon(int dropWeaponIndex) {
    if (dropWeaponIndex < 0 || dropWeaponIndex >= this.Weapons.Count) {
      return false;
    }
    this.Weapons.RemoveAt(dropWeaponIndex);
    return true;
  }

}