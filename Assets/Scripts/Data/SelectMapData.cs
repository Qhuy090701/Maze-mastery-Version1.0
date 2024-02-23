using UnityEngine;

[CreateAssetMenu(fileName = "SelectMapData", menuName = "Data/SelectMapData")]
public class SelectMapData : ScriptableObject {
  [Header("Map Data")]
  public int currentMapIndex;
  public MapData[] MapData;

  public void Init() {
    MapData = Resources.LoadAll<MapData>("DataGame/LevelMap");
    LoadData();
  }

  public void SaveData() {
    PlayerPrefs.SetInt("CurrentMapIndex", currentMapIndex);
    for (int i = 0; i < MapData.Length; i++) {
      PlayerPrefs.SetInt($"Map{i}_isUnlocked", MapData[i].isUnlocked ? 1 : 0);
    }
    PlayerPrefs.Save();
  }

  public void LoadData() {
    currentMapIndex = PlayerPrefs.GetInt("CurrentMapIndex", 0);
    for (int i = 0; i < MapData.Length; i++) {
      int isUnlocked = PlayerPrefs.GetInt($"Map{i}_isUnlocked", 0);
      MapData[i].isUnlocked = isUnlocked == 1;
    }
  }
}