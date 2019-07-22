using UnityEngine;
using Player;
using Weapon;
using System.Collections;
using System.Collections.Generic;

namespace Game {
  public class GameModel {

    public static int MAX_PLAYER_CAPCITY = 100;

    private ArrayList Players = new ArrayList();
    private ArrayList Weapons = new ArrayList();
    private float Duration;


    public GameModel(float duration) {
      this.Duration = duration;
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

    // public boolean IsGameOver(GameStatusCheck check) {
    //   return check(this.)
    // }

  }
}
