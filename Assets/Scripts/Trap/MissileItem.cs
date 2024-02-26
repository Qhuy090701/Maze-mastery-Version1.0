using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileItem : MonoBehaviour {
  [SerializeField] private GameObject missileTrigger;
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag(Constants.Tag_Player)) {
      Instantiate(missileTrigger, RfHolder.Ins.playerPos.transform.position, Quaternion.identity);
      RfHolder.Ins.playerHealth.CheckHealth();
      other.gameObject.SetActive(false);
    }
  }
}