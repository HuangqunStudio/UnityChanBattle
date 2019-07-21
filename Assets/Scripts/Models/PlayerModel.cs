using UnityEngine;
using WeaponModel;

public class PlayerModel {

  public static enum Party { Red, Blue };

  private float healthPoint = 100;
  private float stamina = 100;
  private Party party;
  // TODO: change the magic number here. number of weapons should be limited
  private WeaponModel[] weapons = new WeaponModel[10];

  public boolean isAlive() {
    return this.healthPoint > 0;
  }

  public float getHealthPoint() {
    return this.healthPoint;
  }

  public float getStamina() {
    return this.stamina;
  }

  public Party getParty() {
    return this.party;
  }

  public WeaponModel[] getWeapons() {
    return this.weapons;
  }

  public void receiveDamage(float points) {
    this.healthPoint = this.healthPoint - points;
  }

  public void regainHealth(float points) {
    this.healthPoint = min(100, this.healthPoint + points);
  }

  public void useStamina(float amount) {
    if (this.stamina - this.amount >= 0) {
      this.stamina = this.stamina - amount;
    }
  }

  public void regainStamina(float amount) {
    this.stamina = min(100, this.stamina + amount);
  }

}