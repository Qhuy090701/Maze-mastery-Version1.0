using UnityEngine;

[CreateAssetMenu(fileName = "SelectMapData", menuName = "Data/SelectMap")]
public class MapData : ScriptableObject {
  [Header("Position")]
  public Vector3 startPoint;
  public Vector3 checkPoint;
  
  [Header("Data Map")]
  public int currentLevel;
  public GameObject prefabs;
  public bool isUnlocked;
  public GameObject imgLocked;
}