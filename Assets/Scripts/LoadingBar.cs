using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour {
  [SerializeField] private Slider slider;
  [SerializeField] private float timeToLoad = 3f;

  private void Start() {
    StartCoroutine(LoadProgressBar());
  }

  private IEnumerator LoadProgressBar() {
    float time = 0f;
    while (time < timeToLoad) {
      time += Time.deltaTime;
      slider.value = time / timeToLoad;
      if (slider.value == 1) {
        SceneManager.LoadScene(Constants.Scene_MainMenu);
      }

      yield return null;
    }
  }
}