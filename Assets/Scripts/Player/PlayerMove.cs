using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
  public MoveState moveState;
  public enum  MoveState {
    movewithbutton,
    moveWithKey
  }
  [SerializeField] private Player player;

  private void OnValidate() {
    if (player == null) {
      player = GetComponent<Player>();
    }
  }

  private void Start() {
    player.isMove = true;
    player.isMoveLeft = false;
    player.isMoveRight = false;
  }

  private void Update() {
    if (!player.anim.GetCurrentAnimatorStateInfo(0).IsName(Constants.Anim_PlayerJump) && CheckGround()) {
      player.anim.SetTrigger(Constants.Anim_PlayerIdle);
    }
    //Movenment();
    CheckGround();
    //MovenmentWithKetCode();
    
    switch (moveState) {
      case MoveState.movewithbutton:
        Movenment();
        break;
      case MoveState.moveWithKey:
        MovenmentWithKetCode();
        break;
    }
  }

  public void Jump() {
    if (CheckGround() && player.countJump > 0) {
      AudioManager.Ins.PlaySfx(SoundName.SfxJump);
      player.anim.SetTrigger(Constants.Anim_PlayerJump);
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
      if (CheckGround()) {
        player.anim.SetTrigger(Constants.Anim_PlayerWalk);
      } else {
        player.anim.SetTrigger(Constants.Anim_PlayerJump);
      }
      transform.localScale = new Vector3(-2, 2, 1);
    } else if (player.isMoveRight) {
      player.rb.velocity = new Vector2(player.speedMove, player.rb.velocity.y);
      if (CheckGround()) {
        player.anim.SetTrigger(Constants.Anim_PlayerWalk);
      } else {
        player.anim.SetTrigger(Constants.Anim_PlayerJump);
      }
      transform.localScale = new Vector3(2, 2, 1);
    } else {
      player.rb.velocity = new Vector2(0, player.rb.velocity.y);
      if (CheckGround()) {
        player.anim.SetTrigger(Constants.Anim_PlayerIdle);
      } else {
        player.anim.SetTrigger(Constants.Anim_PlayerJump);
      }
    }
  }
  public void MovenmentWithKetCode() {
    float targetVelocityX = 0;
    if (player.isMove == true) {
      if (Input.GetKey(KeyCode.A)) {
        targetVelocityX = -player.speedMove;
        player.anim.SetTrigger(CheckGround() ? Constants.Anim_PlayerWalk : Constants.Anim_PlayerJump);
        transform.localScale = new Vector3(-2, 2, 1);
      } else if (Input.GetKey(KeyCode.D)) {
        player.anim.SetTrigger(CheckGround() ? Constants.Anim_PlayerWalk : Constants.Anim_PlayerJump);
        targetVelocityX = player.speedMove;
        transform.localScale = new Vector3(2, 2, 1);
      } else if (CheckGround()) {
        player.anim.SetTrigger(Constants.Anim_PlayerIdle);
      } else {
        player.anim.SetTrigger(Constants.Anim_PlayerJump);
      }

      player.rb.velocity = new Vector2(
        Mathf.SmoothDamp(player.rb.velocity.x, targetVelocityX, ref player.velocityX, 0.1f),
        player.rb.velocity.y
      );
    }
  }
  
  public void PointerDownLeft() => player.isMoveLeft = true;
  public void PointerUpLeft() => player.isMoveLeft = false;
  public void PointerDownRight() => player.isMoveRight = true;
  public void PointerUpRight() => player.isMoveRight = false;
}