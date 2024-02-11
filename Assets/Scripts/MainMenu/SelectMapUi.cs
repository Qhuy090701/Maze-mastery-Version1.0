using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMapUi : MonoBehaviour {
  [SerializeField] private SelectMapData selectMapData;

  public void SelectMapIndex(int mapIndex) {
    if (selectMapData.MapData[mapIndex].isUnlocked) {
      selectMapData.currentMapIndex = mapIndex;
      SceneManager.LoadScene(Constants.Scene_StartGame);
    }
  }
}