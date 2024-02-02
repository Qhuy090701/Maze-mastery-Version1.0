using UnityEngine;

public class CreateMap : MonoBehaviour {
  [SerializeField] private SelectMapData selectMapData;

  private void Awake() {
    Instantiate(selectMapData.MapData[selectMapData.currentMapIndex].prefabs, new Vector3(0, 0, 0), Quaternion.identity);
  }
}