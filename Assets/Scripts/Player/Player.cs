using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
  [Header("Player Data")] public float speedMove;

  public float jumpForce;
  public LayerMask groundLayer;
  public int countJump = 1;

  [Header("Player Health")] public int maxHealth = 5;
  public Text healthText;
  
  [Header("Component")] public Rigidbody2D rb;
  public RaycastHit2D hit;

  [Header("Move")] public bool isMove = true;
  public bool isMoveLeft;
  public bool isMoveRight;
  
  [Header("Velocity")] public float velocityX;
  
  [Header("Raycast")] public float raycastHeight = 0.1f;
  public float raycastWidth = 0.5f;
  public float distance = 0.1f;
  
  [Header("PlayerData")] public PlayerData playerData;
  
  [Header("Ui Lose Game")] public GameObject loseUiWithHealth;
  public GameObject loseUiWithoutHealth;
  private void OnValidate() {
    if (rb == null) {
      rb = GetComponent<Rigidbody2D>();
    }
  }
}