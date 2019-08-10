using Player;
using Weapon;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Game {
  public class GameModel {

    public static int MAX_PLAYER_CAPCITY = 100;

    private List<PlayerModel> players = new List<PlayerModel>();
    private List<WeaponModel> weapons = new List<WeaponModel>();
    private double duration;
    private DateTime startTime;

    public List<PlayerModel> Players {
      get {
        return this.players;
      }
    }

    public bool IsTimeUp {
      get {
        DateTime expectedEnd = this.startTime.Add(TimeSpan.FromSeconds(this.duration));
        return DateTime.Compare(expectedEnd, DateTime.Now) <= 0;
      }
    }

    public List<PlayerModel> AlivePlayers {
      get {
        List<PlayerModel> result = new List<PlayerModel>();
        foreach (PlayerModel player in this.players) {
          if (player.IsAlive) {
            result.Add(player);
          }
        }
        return result;
      }
    }

    public List<WeaponModel> Weapons {
      get {
        return this.weapons;
      }
    }

    public GameModel(float duration) {
      this.duration = duration;
      this.startTime = DateTime.Now;
    }

    public bool AddPlayer(PlayerModel player) {
      if (this.players.Count >= MAX_PLAYER_CAPCITY) {
        return false;
      }
      this.players.Add(player);
      return true;
    }

    // public bool IsGameOver(GameStatusCheck check) {
    //   DateTime expectedEnd = this.StartTime.Add(this.Duration);
    //   if (this.IsTimeUp || this.check(this.Players)) {
    //     return true;
    //   }
    //   return false;
    // }
  }

}
