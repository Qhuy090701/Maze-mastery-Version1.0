using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : Trap {
  private void Update() {
    base.Update();
    RaycastCheck();
  }

  protected override void RaycastCheck() {
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.down, distance, playerLayer);
    Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
    if (hitup.collider != null) {
      Destroy(gameObject);
    }
  }
}