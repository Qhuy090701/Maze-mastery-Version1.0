using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class ItemTrap : Trap {
  public enum ItemTrapState {
    missile,
    planet,
    heart,
  }

  [SerializeField] private ItemTrapState itemTrapState;
  [SerializeField] private GameObject missileItem;
  [SerializeField] private GameObject missileGhost;
  [SerializeField] private GameObject planetItem;
  [SerializeField] private Transform pointToSpawnMissile;
  [SerializeField] private Transform pointToSpawnPlanet;

  private bool itemSpawned = false;

  private void Update() {
    base.Update();
    RaycastCheck();
  }

  private void RaycastCheck() {
    var hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
    if (hitup.collider != null && !itemSpawned) {
      GameObject spawnedItem;
      switch (itemTrapState) {
        case ItemTrapState.missile:
          spawnedItem = Instantiate(missileItem, pointToSpawnMissile.transform.position, Quaternion.identity);
          CreateGhostEffect(spawnedItem);
          spawnedItem.transform.DOMove(hitup.transform.position, 0.75f);
          break;
        case ItemTrapState.planet:
          spawnedItem = Instantiate(planetItem, pointToSpawnPlanet.transform.position, Quaternion.identity);
          spawnedItem.transform.DOMove(hitup.transform.position, 0.75f);
          break;
        case ItemTrapState.heart:
          RfHolder.Ins.player.playerData.maxHealth += 1;
          RfHolder.Ins.playerHealth.UpdateHealth();
          Destroy(gameObject);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
      itemSpawned = true;
    }
  }

  private void CreateGhostEffect(GameObject spawnedItem) {
    var mySequence = DOTween.Sequence();
    mySequence.AppendInterval(0.1f).OnStepComplete(() => {
      var ghostMissile = Instantiate(missileGhost, spawnedItem.transform.position, Quaternion.identity);
      var sr = ghostMissile.GetComponent<SpriteRenderer>();
      if (sr != null) {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
      }
      Destroy(ghostMissile, 0.5f);
    });
    mySequence.SetLoops(-1);
  }
}