using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UiPlayAgain : MonoBehaviour {

  public void PlayAgain() {
    SceneManager.LoadScene(Constants.Scene_StartGame);
  }

  public void LoadBackScene() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
  }
}