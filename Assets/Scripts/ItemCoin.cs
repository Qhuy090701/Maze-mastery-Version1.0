using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCoin : MonoBehaviour
{
   private void OnEnable() {
      Destroy(gameObject, 0.5f);
   }
}
