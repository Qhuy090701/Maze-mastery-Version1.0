using UnityEngine;

[CreateAssetMenu(fileName = "SelectMapData", menuName = "Data/SelectMapData")]
public class SelectMapData : ScriptableObject {
  [Header("Map Data")]
  public int currentMapIndex;
  public MapData[] MapData;

  public void Init() {
    MapData = Resources.LoadAll<MapData>("DataGame/LevelMap");
  }
}