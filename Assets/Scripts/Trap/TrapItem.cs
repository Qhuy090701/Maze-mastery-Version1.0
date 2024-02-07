using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrapItem : Trap {

  public TrapItemState trapItemState;
  public enum TrapItemState {
    noHide,
    Hide
  }

  [SerializeField] private SpriteRenderer spriteRenderer;
  [SerializeField] private int countHealth;
  [SerializeField] private GameObject itemTrap;
  [SerializeField] private GameObject itemCoin;
  [SerializeField] private Transform pointToSpawn;

  private bool itemSpawned = false;
  private bool isCollided = false;
  private bool playerCollided = false;

  private void OnValidate() {
    if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
  }
  private void Update() {
    base.Update();
    RaycastCheck();

    switch (trapItemState) {
      case TrapItemState.noHide:
        spriteRenderer.enabled = true;
        break;
      case TrapItemState.Hide:
        spriteRenderer.enabled = isCollided;
        break;
    }
  }

  protected override void RaycastCheck() {
    int countspawn = 1;
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
    RaycastHit2D hitdown = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.down, distance, playerLayer);
    RaycastHit2D hitleft = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.left, distance, playerLayer);
    RaycastHit2D hitright = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.right, distance, playerLayer);
    Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
    if (hitup.collider != null || hitdown.collider != null || hitleft.collider != null || hitright.collider != null){
      if (trapItemState == TrapItemState.Hide && !isCollided) {
        isCollided = true;
        return;
      }
      if (hitdown.collider != null && countHealth > 0 && !playerCollided) {
        countHealth--;
        playerCollided = true;
        GameObject spawnedItem = Instantiate(itemCoin, transform.position, Quaternion.identity);
        spawnedItem.transform.DOMove(pointToSpawn.position, 1f);
      }
      if(countHealth <= 0 && !itemSpawned) {
        countHealth = 0;
        for (int i = 0; i < countspawn; i++) {
          GameObject spawnedItem = Instantiate(itemTrap, transform.position, Quaternion.identity);
          spawnedItem.transform.DOMove(pointToSpawn.position, 0.5f);
        }
        itemSpawned = true;
      }
    } else {
      playerCollided = false;
    }
  }
}