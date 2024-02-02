using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  [Header("Player Data")] public float speedMove;

  public float jumpForce;
  public LayerMask groundLayer;
  public int countJump = 1;

  [Header("Component")] public Rigidbody2D rb;
  public RaycastHit2D hit;
  
  [Header("Move")] public bool isMoveLeft;
  public bool isMoveRight;
  
  [Header("Velocity")] public float velocityX;
  private void OnValidate() {
    if (rb == null) {
      rb = GetComponent<Rigidbody2D>();
    }
  }
}