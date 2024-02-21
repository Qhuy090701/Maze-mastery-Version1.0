using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornTrap : Trap {
  [SerializeField] private Thorntype thornType;

  public enum Thorntype {
    jump,
    die
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag(Constants.Tag_Player)) {
      if(thornType == Thorntype.jump) {
        RfHolder.Ins.playerMove.Jump();
      } else if(thornType == Thorntype.die) {
        RfHolder.Ins.playerHealth.CheckHealth();
      }
    }
  }
}