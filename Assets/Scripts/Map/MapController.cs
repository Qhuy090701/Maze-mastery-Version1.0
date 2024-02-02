using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {
  public Transform startPoint;

  public void Start() {
    RfHolder.Ins.playerPos.position = startPoint.position;
  }
}