using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMapUi : MonoBehaviour {
  [SerializeField] private SelectMapData selectMapData;

  public void SelectMapIndex(int mapIndex) {
    selectMapData.currentMapIndex = mapIndex;
    SceneManager.LoadScene(Constants.Scene_StartGame);
  }
}