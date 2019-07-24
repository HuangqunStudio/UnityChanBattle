using UnityEngine;
using Player;
using Weapon;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Game {
  public class GameModel {

    public static int MAX_PLAYER_CAPCITY = 100;

    private ArrayList Players = new ArrayList();
    private ArrayList Weapons = new ArrayList();
    private double Duration;
    private DateTime StartTime;


    public GameModel(float duration) {
      this.Duration = duration;
      this.StartTime = DateTime.Now;
    }

    public bool AddPlayer(PlayerModel player) {
      if (this.Players.Count >= MAX_PLAYER_CAPCITY) {
        return false;
      }
      this.Players.Add(player);
      return true;
    }

    public List<PlayerModel> GetAlivePlayers() {
      List<PlayerModel> result = new List<PlayerModel>();
      foreach (PlayerModel player in this.Players) {
        if (player.IsAlive()) {
          result.Add(player);
        }
      }
      return result;
    }

    public boolean IsGameOver(GameStatusCheck check) {
      DateTime expectedEnd = this.StartTime.Add(this.Duration);
      if (this.check(this.Players) && DateTime.Compare(expectedEnd, DateTime.Now) >= 0) {
        return true;
      }
      return false;
    }

    public Boolean IsTimeUp() {
      DateTime expectedEnd = this.StartTime.Add(this.Duration);
      return DateTime.Compare(expectedEnd, DateTime.Now) <= 0;
    }
  }
}
