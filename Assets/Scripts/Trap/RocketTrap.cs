using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RocketTrap : Trap {
  public RocketTrapState rocketTrapState;

  public enum RocketTrapState {
    Idle,
    Move,
    Die
  }

  [SerializeField] private Transform pointToMove;

  private void Update() {
    switch (rocketTrapState) {
      case RocketTrapState.Idle:
        RaycastCheck();
        break;
      case RocketTrapState.Move:
        MoveToPoint();
        break;
      case RocketTrapState.Die:
        CheckDie();
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }

protected override void RaycastCheck() {
  RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
  RaycastHit2D hitdown = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.down, distance, playerLayer);
  RaycastHit2D hitright = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.right, distance, playerLayer);
  RaycastHit2D hitleft = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.left, distance, playerLayer);
  Debug.DrawRay(transform.position, Vector2.up * distance, Color.red);
  Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
  Debug.DrawRay(transform.position, Vector2.right * distance, Color.red);
  Debug.DrawRay(transform.position, Vector2.left * distance, Color.red);
  if (hitup.collider != null && hitup.transform != null) {
    hitup.transform.position = gameObject.transform.position;
    hitup.transform.SetParent(transform);
    hitup.transform.localPosition = Vector3.zero;
    hitup.transform.GetComponent<Rigidbody2D>().gravityScale = 0;
    rocketTrapState = RocketTrapState.Move;
  }
  else if (hitdown.collider != null && hitdown.transform != null) {
    hitdown.transform.position = gameObject.transform.position;
    hitdown.transform.SetParent(transform);
    hitdown.transform.localPosition = Vector3.zero;
    hitdown.transform.GetComponent<Rigidbody2D>().gravityScale = 0;
    rocketTrapState = RocketTrapState.Move;
  }
  else if (hitright.collider != null && hitright.transform != null) {
    hitright.transform.position = gameObject.transform.position;
    hitright.transform.SetParent(transform);
    hitright.transform.localPosition = Vector3.zero;
    hitright.transform.GetComponent<Rigidbody2D>().gravityScale = 0;
    rocketTrapState = RocketTrapState.Move;
  }
  else if (hitleft.collider != null && hitleft.transform != null) {
    hitleft.transform.position = gameObject.transform.position;
    hitleft.transform.SetParent(transform);
    hitleft.transform.localPosition = Vector3.zero;
    hitleft.transform.GetComponent<Rigidbody2D>().gravityScale = 0;
    rocketTrapState = RocketTrapState.Move;
  }
}
  private void CheckDie() {
    DOTween.Sequence().AppendInterval(1f).OnComplete(() => { Destroy(gameObject); });
  }

  private void MoveToPoint() {
    transform.DOMove(pointToMove.position, 1f).OnComplete(() => { rocketTrapState = RocketTrapState.Die; });
  }
}