using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WinObject : MonoBehaviour {
  public WinState winState;

  public enum WinState {
    lose,
    win,
    ComingSoon
  }


  [SerializeField] private GameObject winUi;
  [SerializeField] private Canvas canvas;
  [SerializeField] private int nextLevelUnlock;
  [SerializeField] private SelectMapData selectMapData;
  [SerializeField] private GameObject comingSoonUi;

  private void Start() {
    SetCanvas();
  }

  private void SetCanvas() {
    if (canvas == null) {
      canvas = RfHolder.Ins.canvas;
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag(Constants.Tag_Player)) {
      if (winState == WinState.lose) {
        other.gameObject.SetActive(false);
        PlayerLose();
      }
      else if (winState == WinState.win) {
        AudioManager.Ins.PlaySfx(SoundName.SfxWinGame);
        other.gameObject.SetActive(false);
        ShowWinUI();
        UnlockNextLevel();
      }
      else if (winState == WinState.ComingSoon) {
        GameObject comingSoon = Instantiate(comingSoonUi, Vector3.zero, Quaternion.identity);
        comingSoon.transform.SetParent(canvas.transform, false);
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

  public void PlayerLose() {
    RfHolder.Ins.playerHealth.CheckHealth();
  }
}