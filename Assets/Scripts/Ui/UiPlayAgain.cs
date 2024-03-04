using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UiPlayAgain : MonoBehaviour {
  public void PlayAgain(GameObject btn_playAgain) {
    btn_playAgain.SetActive(true);
    DOVirtual.DelayedCall(1.5f, LoadStartGameScene);
  }

  private void LoadStartGameScene() {
    SceneManager.LoadScene(Constants.Scene_StartGame);
  }

  public void LoadBackScene(GameObject btn_back) {
    btn_back.SetActive(true);
    DOVirtual.DelayedCall(1.5F, LoadNewScene);
  }
  
  public void LoadNewScene() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
  }
}