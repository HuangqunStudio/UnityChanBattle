using UnrealEngine;

public class WeaponModel {

  public static enum WeaponType { sword, dagger, staff }

  private string name;
  private string description;
  private WeaponType type;
  private float damage;
  private float attackInterval;
  private float durable;
  private float usage;

  public WeaponModel(string name, string description, WeaponType type, float damage, float attackInterval, float durable, float usage) {
    this.name = name;
    this.description = description;
    this.type = type;
    this.damage = damage;
    this.attackInterval = attackInterval;
    this.durable = durable;
    this.usage = usage;
  }
  
  public string GetName() {
    return this.name;
  }

  public string GetDescription() {
    return this.description;
  }

  public WeaponType GetType() {
    return this.type;
  }

  public float GetDamage() {
    return this.damage;
  }

  public float GetAttackInterval() {
    return this.attackInterval;
  }
  public float GetDurable() {
    return this.durable;
  }

  public float GetUsage() {
    return this.usage;
  }

  public boolean IsUsable() {
    return this.durable > 0;
  }

  // this function will only be called when weapon really
  // hit some objects
  public void UseWeapon() {
    this.durable = this.durable - this.usage;
  }

}