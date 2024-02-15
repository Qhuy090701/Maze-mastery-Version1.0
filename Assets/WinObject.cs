using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WinObject : MonoBehaviour {
  [SerializeField] private GameObject winUi;
  [SerializeField] private Canvas canvas;
  
  private void Start() {
    if (canvas == null) {
      canvas = RfHolder.Ins.canvas;
    }
    float originalY = transform.position.y;
    DOTween.Sequence()
      .Append(transform.DOMoveY(originalY + 0.5f, 1f).SetEase(Ease.InOutSine))
      .Append(transform.DOMoveY(originalY, 1f).SetEase(Ease.InOutSine))
      .SetLoops(-1);
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      Debug.Log("Win");
      GameObject win = Instantiate(winUi, Vector3.zero, Quaternion.identity);
      win.transform.SetParent(canvas.transform, false);
    }
  }
}