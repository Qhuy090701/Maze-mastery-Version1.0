using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BrickPoint : Trap {
  [SerializeField] private Animator animator;
  
  private void Awake() {
    if (animator == null) animator = GetComponent<Animator>();
    animator.SetTrigger(Constants.Anim_BrickIdle);
  }

  private void Update() {
    base.Update();
    RaycastCheck();
  }

  protected override void RaycastCheck() {
    RaycastHit2D hitdown = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.down, distance, playerLayer);
    if (hitdown.collider != null) {
      animator.SetTrigger(Constants.Anim_BrickBroken);
      AudioManager.Ins.PlaySfx(SoundName.SfxBrokenBrick);
      DOTween.Sequence().AppendInterval(0.5f).OnComplete(() => {
        Destroy(gameObject);
      });
    }
  }
}