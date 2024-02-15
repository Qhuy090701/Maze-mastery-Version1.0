using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemTrap : Trap {
  [SerializeField] private ItemTrapState itemTrapState;
  public enum ItemTrapState {
    missile,
    heart
  }
  [SerializeField] private GameObject missileItem;
  [SerializeField] private GameObject heartItem;
  [SerializeField] private Transform pointToSpawnMissile;
  [SerializeField] private Transform pointToSpawnHeart;

  private bool itemSpawned = false;

  private void Update() {
    base.Update();
    RaycastCheck();
  }

  private void RaycastCheck() {
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
    Debug.DrawRay(transform.position, transform.position, Color.red);
    if (hitup.collider != null && !itemSpawned) {
      GameObject spawnedItem;
      switch (itemTrapState) {
        case ItemTrapState.missile:
          spawnedItem = Instantiate(missileItem, pointToSpawnMissile.transform.position, Quaternion.identity);
          break;
        case ItemTrapState.heart:
          spawnedItem = Instantiate(heartItem, pointToSpawnHeart.transform.position, Quaternion.identity);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
      spawnedItem.transform.DOMove(hitup.transform.position, 0.5f);
      itemSpawned = true;
    }
  }
}