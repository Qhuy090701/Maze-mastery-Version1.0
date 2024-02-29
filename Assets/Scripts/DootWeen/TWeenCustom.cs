using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TWeenCustom : MonoBehaviour {
  public TweenType type;

  public enum TweenType {
    Scale,
    ScaleLoop,
    Move,
    Rotate,
    Flicker,
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
        RotateEffect();
        break;
      case TweenType.Flicker:
        FlickEffect();
        break;
      case TweenType.ScaleLoop:
        ScaleEffect();
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

  private void RotateEffect() {
    DOTween.Sequence()
      .Append(transform.DORotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360))
      .SetLoops(-1);
  }

  public void ScaleEffect() {
    DOTween.Sequence()
      .Append(transform.DOScale(Vector3.one * 1.5f, 1f))
      .Append(transform.DOScale(Vector3.one, 2f))
      .SetLoops(-1);
  }
}