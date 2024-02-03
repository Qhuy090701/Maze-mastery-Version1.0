using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemTrap : Trap {
  [SerializeField] private GameObject itemTrap;
  [SerializeField] private Transform pointToSpawn;

  private bool itemSpawned = false;

  private void Update() {
    base.Update();
    RaycastCheck();
  }

  private void RaycastCheck() {
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
    Debug.DrawRay(transform.position, transform.position, Color.red);
    if (hitup.collider != null && !itemSpawned) {
      GameObject spawnedItem = Instantiate(itemTrap, pointToSpawn.transform.position, Quaternion.identity);
      spawnedItem.transform.DOMove(hitup.transform.position, 1f);
      itemSpawned = true;
    }
  }
}