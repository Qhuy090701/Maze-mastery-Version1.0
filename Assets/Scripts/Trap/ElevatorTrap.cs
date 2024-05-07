using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrap : Trap {
  public ElevatorState elevatorState;
  public MovementType movementType;

  public enum ElevatorState {
    NoneTrap,
    Trap,
    TrapTeleport
  }

  public enum MovementType {
    DontMove,
    MoveAToB,
    MoveTriangle
  }

  [SerializeField] private float speed;
  [SerializeField] private Transform pointA;
  [SerializeField] private Transform pointB;
  [SerializeField] private Transform pointC;
  [SerializeField] private Transform teleportPoint;
  private bool movingToA = true;

  private void Update() {
    HandleMovement();
    HandleElevatorState();
  }

  private void HandleMovement() {
    switch (movementType) {
      case MovementType.DontMove:
        break;
      case MovementType.MoveAToB:
        MoveAToB();
        break;
      case MovementType.MoveTriangle:
        MoveTriangle();
        break;
    }
  }

  private void HandleElevatorState() {
    switch (elevatorState) {
      case ElevatorState.NoneTrap:
        break;
      case ElevatorState.Trap:
        TrapMoveOn();
        break;
      case ElevatorState.TrapTeleport:
        Teleport();
        break;
    }
  }

  private void MoveAToB() {
    Vector3 targetPosition = movingToA ? pointA.position : pointB.position;
    Vector3 currentPosition = transform.position;
    currentPosition = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
    transform.position = currentPosition;

    if (currentPosition == targetPosition) {
      movingToA = !movingToA;
    }
  }

  private int currentPoint = 0;

  private void MoveTriangle() {
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
      hitup.collider.gameObject.SetActive(false);
      RfHolder.Ins.playerHealth.CheckHealth();
    }
  }

  private void Teleport() {
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
    if (hitup.collider != null) {
      hitup.transform.position = teleportPoint.position;
    }
  }
}