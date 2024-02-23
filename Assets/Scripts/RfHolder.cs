using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RfHolder : Singleton<RfHolder> {
 public Transform playerPos;
 public Canvas canvas;
 public PlayerHealth playerHealth;
 public Player player;
 public PlayerMove playerMove;
 public CameraFollow cameraFollow;

 private void OnValidate() {
  if (playerPos == null) {
   playerPos = GameObject.Find("Player").transform;
  }
  
  if (canvas == null) {
   canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
  }
  
  if (playerHealth == null) {
   playerHealth = FindObjectOfType<PlayerHealth>();
  }
  
  if (player == null) {
   player = FindObjectOfType<Player>();
  }
  
  if (playerMove == null) {
   playerMove = FindObjectOfType<PlayerMove>();
  }
  
  if (cameraFollow == null) {
   cameraFollow = FindObjectOfType<CameraFollow>();
  }
 }
}