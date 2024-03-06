using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMapUi : MonoBehaviour {
  [SerializeField] private SelectMapData selectMapData;
  [SerializeField] private PlayerData playerData;
  public void Start() {
    selectMapData.LoadData();
    selectMapData.MapData[0].isUnlocked = true;
    selectMapData.SaveData();
  }
  public void SelectMapIndex(int mapIndex) {
    if (selectMapData.MapData[mapIndex].isUnlocked) {
      if (playerData.maxHealth > 0) {
        selectMapData.currentMapIndex = mapIndex;
        SceneManager.LoadScene(Constants.Scene_StartGame);
      }
      else {
        Debug.Log("Health = 0");
      }
    }
  }
}