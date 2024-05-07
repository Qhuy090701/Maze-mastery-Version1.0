using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RfHolder : Singleton<RfHolder> {
 public Transform playerPos;
 public Canvas canvas;
 public PlayerHealth playerHealth;
 public Player player;
 public PlayerMove playerMove;
 [FormerlySerializedAs("cameraFollow")] public CamereTarget camereTarget;

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
  
  if (camereTarget == null) {
   camereTarget = FindObjectOfType<CamereTarget>();
  }
 }
}