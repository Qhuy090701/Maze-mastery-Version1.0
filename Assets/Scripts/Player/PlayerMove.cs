using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
  [SerializeField] private Player player;

  private void OnValidate() {
    if (player == null) {
      player = GetComponent<Player>();
    }
  }

  private void Update() {
    CheckGround();
  }

  public void Jump() {
    if (CheckGround() && player.countJump > 0) {
      player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);
      player.countJump--;
    }
  }
  
  public bool CheckGround() {
    player.hit = Physics2D.Raycast(transform.position, Vector2.down, 0.55f, player.groundLayer);
    player.countJump = player.hit.collider != null ? 1 : 0;
    return player.hit.collider != null;
  }
}