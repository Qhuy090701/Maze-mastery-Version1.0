using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour {
  [SerializeField] protected float raycastHeight = 0.1f;
  [SerializeField] protected float raycastWidth = 0.5f;
  [SerializeField] protected float distance = 0.1f;
  [SerializeField] protected LayerMask playerLayer;

  protected virtual void Update() {
    RaycastCheck();
  }

  protected virtual void RaycastCheck() {
  }
}