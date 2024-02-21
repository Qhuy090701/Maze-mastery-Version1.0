using UnityEngine;

public class SelectUi : MonoBehaviour {
  [SerializeField] private SelectMapData selectMapData;

  public void SelectUiCanvas(GameObject prefab) {
    Instantiate(prefab, transform);
    selectMapData.Init();
  }
  
  public void DestroyUiCanvas(GameObject prefab){
    Destroy(prefab);
  }
}