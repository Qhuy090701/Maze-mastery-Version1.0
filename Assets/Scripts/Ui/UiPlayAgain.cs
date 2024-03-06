using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UiPlayAgain : MonoBehaviour {
  [SerializeField] private PlayerData playerData;
  [SerializeField] private GameObject inAppUi;
  public void PlayAgain(GameObject btnPlayAgain) {
    if (playerData.maxHealth > 0) {
      btnPlayAgain.SetActive(true);
      DOVirtual.DelayedCall(1.5f, LoadStartGameScene);
    }
    else {
       Debug.Log("Health = 0");
    }
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

  public void InApp() {
    GameObject inappUi = Instantiate(inAppUi, RfHolder.Ins.canvas.transform);
  }
}