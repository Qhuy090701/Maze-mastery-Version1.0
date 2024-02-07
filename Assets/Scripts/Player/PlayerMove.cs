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

  private void Start() {
    player.isMoveLeft = false;
    player.isMoveRight = false;
  }

  private void Update() {
    //Movenment();
    CheckGround();
    MovenmentWithKetCode();
  }

  public void Jump() {
    if (CheckGround() && player.countJump > 0) {
      player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);
      player.countJump--;
    }
  }
  
  public bool CheckGround() {
    player.hit = Physics2D.BoxCast(transform.position, new Vector2(player.raycastWidth, player.raycastHeight), 0f, Vector2.down, player.distance, player.groundLayer);
    player.countJump = player.hit.collider != null ? 1 : 0;
    return player.hit.collider != null;
  }
  
  public void Movenment() {
    if (player.isMoveLeft) {
      player.rb.velocity = new Vector2(-player.speedMove, player.rb.velocity.y);
    } else if (player.isMoveRight) {
      player.rb.velocity = new Vector2(player.speedMove, player.rb.velocity.y);
    } else {
      player.rb.velocity = new Vector2(0, player.rb.velocity.y);
    }
  }
  
  public void MovenmentWithKetCode() {
    float targetVelocityX = 0;
    if (Input.GetKey(KeyCode.A)) {
      targetVelocityX = -player.speedMove;
    } else if (Input.GetKey(KeyCode.D)) {
      targetVelocityX = player.speedMove;
    }

    player.rb.velocity = new Vector2(
      Mathf.SmoothDamp(player.rb.velocity.x, targetVelocityX, ref player.velocityX, 0.1f),
      player.rb.velocity.y
    );
  }
  
  public void PointerDownLeft() => player.isMoveLeft = true;
  public void PointerUpLeft() => player.isMoveLeft = false;
  public void PointerDownRight() => player.isMoveRight = true;
  public void PointerUpRight() => player.isMoveRight = false;
}