using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WinObject : MonoBehaviour {
  public WinState winState;
  public StateMove stateMove;

  public enum WinState {
    lose,
    win,
  }

  public enum StateMove {
    NotMove,
    Move
  }

  [SerializeField] private GameObject winUi;
  [SerializeField] private Canvas canvas;
  [SerializeField] private int nextLevelUnlock;
  [SerializeField] private SelectMapData selectMapData;

  private void Start() {
    SetCanvas();
  }

  private void SetCanvas() {
    if (canvas == null) {
      canvas = RfHolder.Ins.canvas;
    }
  }

  private void Update() {
    if (winState == WinState.win) {
      if (Vector2.Distance(transform.position, RfHolder.Ins.player.transform.position) < 1) {
        ShowWinUI();
        UnlockNextLevel();
      }
    }
    else if (winState == WinState.lose) {
      Checkdistance();
      if (stateMove == StateMove.Move) {
        StartMoveEffect();
      }
    }
  }

  private void StartMoveEffect() {
    float originalY = transform.position.y;
    DOTween.Sequence()
      .Append(transform.DOMoveY(originalY + 0.5f, 0.5f).SetEase(Ease.InOutSine))
      .Append(transform.DOMoveY(originalY, 0.5f).SetEase(Ease.InOutSine))
      .SetLoops(-1);
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag(Constants.Tag_Player)) {
      if (winState == WinState.lose) {
        PlayerLose();
      }
      else if (winState == WinState.win) {
        ShowWinUI();
        UnlockNextLevel();
      }
    }
  }

  private void ShowWinUI() {
    GameObject win = Instantiate(winUi, Vector3.zero, Quaternion.identity);
    win.transform.SetParent(canvas.transform, false);
  }

  public void UnlockNextLevel() {
    selectMapData.MapData[nextLevelUnlock].isUnlocked = true;
    selectMapData.SaveData();
  }

  public void Checkdistance() {
    if (Vector2.Distance(transform.position, RfHolder.Ins.player.transform.position) < 1) {
      PlayerLose();
    }
  }

  public void PlayerLose() {
    RfHolder.Ins.playerHealth.CheckHealth();
  }
}