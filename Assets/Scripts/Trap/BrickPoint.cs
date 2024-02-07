using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPoint : Trap {
  private void Update() {
    base.Update();
    RaycastCheck();
  }

  protected override void RaycastCheck() {
    RaycastHit2D hitdown = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.down, distance, playerLayer);
    if (hitdown.collider != null) {
      Destroy(gameObject);
    }
  }
}