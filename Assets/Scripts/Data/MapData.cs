using UnityEngine;

[CreateAssetMenu(fileName = "SelectMapData", menuName = "Data/SelectMap")]
public class MapData : ScriptableObject {
  public int currentLevel;
  public GameObject prefabs;
  public bool isUnlocked;
  public GameObject imgLocked;
}