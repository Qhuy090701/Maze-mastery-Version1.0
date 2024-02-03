using UnityEngine;

public class DrainTrap : Trap {
  [SerializeField] private Transform pointTeleport;

  private void Update() {
    base.Update();
    RaycastCheck();
  }

  protected override void RaycastCheck() {
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
    Debug.DrawRay(transform.position, Vector2.up * distance, Color.red);
    if (hitup.collider != null) {
      hitup.transform.position = pointTeleport.position;
    }
  }
}