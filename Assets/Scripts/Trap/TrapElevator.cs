using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapElevator : Trap {
  public ElevatorState elevatorState;

  public enum ElevatorState {
    NoneTrap,
    Trap
  }

  [SerializeField] private float speed;
  [SerializeField] private Transform pointA;
  [SerializeField] private Transform pointB;
  private bool movingToA = true;

  private void Update() {
    TrapElevatorMovement();
    base.Update();
  }

  private void TrapElevatorMovement() {
    if (elevatorState == ElevatorState.NoneTrap) {
      Vector3 targetPosition = movingToA ? pointA.position : pointB.position;
      Vector3 currentPosition = transform.position;
      currentPosition = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
      transform.position = currentPosition;

      if (currentPosition == targetPosition) {
        movingToA = !movingToA;
      }
    }
  }

  protected override void RaycastCheck() {
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
    if (hitup.collider != null) {
      hitup.transform.SetParent(transform);
    }
    else {
      transform.DetachChildren();
    }
  }
}