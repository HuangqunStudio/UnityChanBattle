using UnityEngine;
using WeaponModel;

public class PlayerModel {

  public static enum Party { Red, Blue };
  private string name;
  private boolean isBot;
  private float healthPoint = 100;
  private float stamina = 100;
  private Party party;
  // TODO: change the magic number here. number of weapons should be limited
  private WeaponModel[] weapons = new WeaponModel[10];

  public PlayerModel(Party party, string name, boolean isBot) {
    this.party = party;
    this.name = name;
    this.isBot = isBot;
  }

  public boolean IsAlive() {
    return this.healthPoint > 0;
  }

  public string GetName() {
    return this.name;
  }

  public boolean IsBot() {
    return this.isBot;
  }

  public float GetHealthPoint() {
    return this.healthPoint;
  }

  public float GetStamina() {
    return this.stamina;
  }

  public Party GetParty() {
    return this.party;
  }

  public WeaponModel[] GetWeapons() {
    return this.weapons;
  }

  public void ReceiveDamage(float points) {
    this.healthPoint = this.healthPoint - points;
  }

  public void RegainHealth(float points) {
    this.healthPoint = min(100, this.healthPoint + points);
  }

  public void UseStamina(float amount) {
    if (this.stamina - this.amount >= 0) {
      this.stamina = this.stamina - amount;
    }
  }

  public void RegainStamina(float amount) {
    this.stamina = min(100, this.stamina + amount);
  }

}