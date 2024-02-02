using UnityEngine;

public class SelectUi : MonoBehaviour {
  public void SelectUiCanvas(GameObject prefab) {
    Instantiate(prefab, transform);
  }
}