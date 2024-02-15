using UnityEngine;

public class DrainTrap : Trap {
  public TrapType trapType;
  public enum TrapType {
    Drain,
    Teleport
  }
  [SerializeField] private Transform pointTeleport;
  private void Update() {
    switch (trapType) {
      case TrapType.Drain:
        break;
      case TrapType.Teleport:
        RaycastCheck();
        break;
    }
  }

  protected override void RaycastCheck() {
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
    Debug.DrawRay(transform.position, Vector2.up * distance, Color.red);
    if (hitup.collider != null) {
      hitup.transform.position = pointTeleport.position;
    }
  }
}