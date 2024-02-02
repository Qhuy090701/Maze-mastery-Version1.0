using UnityEngine;

[CreateAssetMenu(fileName = "SelectMapData", menuName = "Data/SelectMapData")]
public class SelectMapData : ScriptableObject {
  public int currentMapIndex;
  public MapData[] MapData;
}
