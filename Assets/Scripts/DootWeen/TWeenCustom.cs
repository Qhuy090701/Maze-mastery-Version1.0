using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TWeenCustom : MonoBehaviour {
  public TweenType type;

  public enum TweenType {
    Scale,
    Move,
    Rotate,
    Flicker
  }

  [SerializeField] private float timeToDelay;
  private void Start() {
    switch (type) {
      case TweenType.Scale:
        transform.localScale = Vector3.zero;
        DOVirtual.DelayedCall(timeToDelay, StartScaleEffect);
        break;
      case TweenType.Move:
        break;
      case TweenType.Rotate:
        break;
      case TweenType.Flicker:
        FlickEffect();
        break;
    }
  }

  private void StartScaleEffect() {
    transform.localScale = Vector3.zero;
    DOTween.Sequence()
      .Append(transform.DOScale(Vector3.one, 1f))
      .SetEase(Ease.InOutQuad);
  }

  private void FlickEffect() {
    DOTween.Sequence()
      .Append(transform.DOScale(Vector3.one * 1.2f, 0.25f))
      .Append(transform.DOScale(Vector3.one, 0.25f))
      .SetLoops(-1);
  }
}