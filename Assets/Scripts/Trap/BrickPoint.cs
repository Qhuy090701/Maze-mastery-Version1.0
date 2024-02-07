using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BrickPoint : Trap {
  private void Update() {
    base.Update();
    RaycastCheck();
  }

  protected override void RaycastCheck() {
    RaycastHit2D hitdown = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.down, distance, playerLayer);
    if (hitdown.collider != null) {
      DOTween.Sequence().AppendInterval(0.25f).OnComplete(() => {
        Destroy(gameObject);
      });
    }
  }
}