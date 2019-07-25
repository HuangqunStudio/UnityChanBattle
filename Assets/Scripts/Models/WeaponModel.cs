using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Weapon {
  public class WeaponModel {

    public enum WeaponType { Sword, Dagger, Staff };
    public enum WeaponRarity { Normal, Rare, VeryRare, UltraRare };

    private string name;
    private string description;
    private WeaponType weaponType;
    private float damage;
    private float attackInterval;
    private float durability;
    private float usage;
    private WeaponRarity rarity;
    private Tuple<float, float, float> location;
    private bool isPicked = false;

    public string Name {
      get {
        return this.name;
      }
    }

    public string description {
      get {
        return this.description;
      }
    }

    public WeaponType WeaponType {
      get {
        return this.weaponType;
      }
    }

    public float Damage {
      get {
        return this.damage;
      }
    }

    public float AttackInterval {
      get {
        return this.attackInterval;
      }
    }

    public float Durability {
      get {
        return this.durability;
      }
    }

    public float Usage {
      get {
        return this.usage;
      }
    }
    
    public WeaponRarity Rarity {
      get {
        return this.rarity;
      }
    }

    public Tuple<float, float, float> Location {
      get {
        return this.location;
      }
    }

    public bool IsPicked {
      get {
        return this.isPicked;
      }
    }

    public bool IsUsable {
      get {
        return this.durability > 0;
      }
    }

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

    // this function will only be called when weapon really
    // hit some objects
    public void UseWeapon() {
      this.durability = this.durability - this.usage;
    }

  }
}
