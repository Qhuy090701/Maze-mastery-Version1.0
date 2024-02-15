using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RfHolder : Singleton<RfHolder> {
 public Transform playerPos;
 public Canvas canvas;

 private void OnValidate() {
  if (playerPos == null) {
   playerPos = GameObject.Find("Player").transform;
  }
  
  if (canvas == null) {
   canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
  }
 }
}