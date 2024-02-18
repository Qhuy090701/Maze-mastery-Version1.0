using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag(Constants.Tag_Player)) {
      if (RfHolder.Ins.player.playerData.maxHealth > 1) {
        RfHolder.Ins.player.playerData.maxHealth--;
        RfHolder.Ins.playerHealth.UpdateHealth();
        UnityEngine.SceneManagement.SceneManager.LoadScene(Constants.Scene_StartGame);
      }
      else {
        RfHolder.Ins.player.playerData.maxHealth = 5;
        RfHolder.Ins.playerHealth.UpdateHealth();
        UnityEngine.SceneManagement.SceneManager.LoadScene(Constants.Scene_StartGame);
      }
    }
  }
}