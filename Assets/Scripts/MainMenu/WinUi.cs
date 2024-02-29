using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUi : MonoBehaviour {
  
  public void NextLevel(int level) {
    SceneManager.LoadScene(level);
  }
}