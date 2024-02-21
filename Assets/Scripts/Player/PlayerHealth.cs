using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
  [SerializeField] private Player player;

  private void OnValidate() {
    if (player == null) {
      player = GetComponent<Player>();
    }
  }

  private void Start() {
    UpdateHealth();
  }

  public void UpdateHealth() {
    player.maxHealth = player.playerData.maxHealth;
    player.healthText.text = "Health: " + player.maxHealth;
    // if (player.maxHealth <= 0) {
    //   player.isDead = true;
    //   player.gameObject.SetActive(false);
    // }
    
  }

  public void CheckHealth() {
    if(player.playerData.maxHealth > 1) {
      player.playerData.maxHealth--;
      UpdateHealth();
      Instantiate(player.loseUiWithHealth, RfHolder.Ins.canvas.transform);
    }
    else {
      player.playerData.maxHealth = 5;
      UpdateHealth();
      Instantiate(player.loseUiWithoutHealth, RfHolder.Ins.canvas.transform);
    }
  }
}