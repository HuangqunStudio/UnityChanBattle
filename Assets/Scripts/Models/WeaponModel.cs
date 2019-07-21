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
  
  public string getName() {
    return this.name;
  }

  public string getDescription() {
    return this.description;
  }

  public WeaponType getType() {
    return this.type;
  }

  public float getDamage() {
    return this.damage;
  }

  public float getAttackInterval() {
    return this.attackInterval;
  }
  public float getDurable() {
    return this.durable;
  }

  public float getUsage() {
    return this.usage;
  }

  public boolean isUsable() {
    return this.durable > 0;
  }

  // this function will only be called when weapon really
  // hit some objects
  public void useWeapon() {
    this.durable = this.durable - this.usage;
  }

}