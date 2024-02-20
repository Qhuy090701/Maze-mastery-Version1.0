using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornTrap : Trap {
  [SerializeField] private Thorntype thornType;

  public enum Thorntype {
    jump,
    die
  }

  private void Update() {
    switch (thornType) {
      case Thorntype.jump:
        RaycastCheck();
        break;
      case Thorntype.die:
        RaycastCheck();
        break;
    }
  }

  protected override void RaycastCheck() {
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
    if (hitup.collider != null) {
      if(thornType == Thorntype.jump) {
        RfHolder.Ins.playerMove.Jump();
      } else if(thornType == Thorntype.die) {
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
}