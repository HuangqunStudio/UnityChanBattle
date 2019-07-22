using UnrealEngine;

public class WeaponModel {

  public static enum WeaponType { sword, dagger, staff }
  public static enum WeaponRarity { normal, rare, veryRare, ultraRare }

  private string name;
  private string description;
  private WeaponType type;
  private float damage;
  private float attackInterval;
  private float durable;
  private float usage;
  private WeaponRarity rarity;
  private Tuple<float, float, float> location;
  private boolean isPicked = false;

  public WeaponModel(string name, string description, WeaponType type, float damage, float attackInterval, float durable, float usage, WeaponRarity rarity, float x, float y, float z) {
    this.name = name;
    this.description = description;
    this.type = type;
    this.damage = damage;
    this.attackInterval = attackInterval;
    this.durable = durable;
    this.usage = usage;
    this.rarity = rarity;
    this.location = Tuple.Create(x, y, z);
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