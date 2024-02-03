using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapElevator : Trap {
  public ElevatorState elevatorState;

  public enum ElevatorState {
    NoneTrap,
    Trap,
    TrapTeleport
  }

  [SerializeField] private float speed;
  [SerializeField] private Transform pointA;
  [SerializeField] private Transform pointB;
  [SerializeField] private Transform pointC; 
  [SerializeField] private Transform teleportPoint;
  private bool movingToA = true;

  private void Update() {
    switch (elevatorState) {
      case ElevatorState.NoneTrap:
        TrapElevatorMovement();
        break;
      case ElevatorState.Trap:
        TrapMoveOn();
        break;
      case ElevatorState.TrapTeleport:
        Teleport();
        break;
    }

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

  private void TrapMoveOn() {
    raycastWidth = 0.5f;
    raycastHeight = 0.5f;
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
    if (hitup.collider != null) {
      Destroy(hitup.collider.gameObject);
    }
  }
  

  private int currentPoint = 0; 

  private void Teleport() {
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);

    Vector3 targetPosition;
    switch (currentPoint) {
      case 0:
        targetPosition = pointA.position;
        break;
      case 1:
        targetPosition = pointB.position;
        break;
      case 2:
        targetPosition = pointC.position;
        break;
      default:
        targetPosition = pointA.position;
        break;
    }

    Vector3 currentPosition = transform.position;
    currentPosition = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
    transform.position = currentPosition;

    if (currentPosition == targetPosition) {
      currentPoint = (currentPoint + 1) % 3;
    }

    if (hitup.collider != null) {
      hitup.transform.position = teleportPoint.position;
    }
  }
}