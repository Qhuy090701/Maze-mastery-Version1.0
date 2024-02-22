using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TWeenCustom : MonoBehaviour {
  public TweenType type;
  public enum TweenType {
    Scale,
    Move,
    Rotate
  }

  private void Start() {
    switch (type) {
      case TweenType.Scale:
        transform.localScale = Vector3.zero;
        DOTween.Sequence()
          .Append(transform.DOScale(Vector3.one, 1f))
          .SetEase(Ease.InOutQuad);
        break;
      case TweenType.Move:
        break;
      case TweenType.Rotate:
        break;
    }
  }
}