using UnityEngine;
using UnityEngine.UI;

public class CreateMap : MonoBehaviour {
  [SerializeField] private SelectMapData selectMapData;
  [SerializeField] private Text textLevelmap;
  private void Awake() {
    Instantiate(selectMapData.MapData[selectMapData.currentMapIndex].prefabs, new Vector3(0, 0, 0), Quaternion.identity);
  }
  
  private void Start() {
    textLevelmap.text = "Level " + (selectMapData.MapData[selectMapData.currentMapIndex].currentLevel + 1);
  }
}