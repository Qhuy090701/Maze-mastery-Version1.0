using System.Collections;
using UnityEngine;

public class TrapWallBehavior : Trap {
  [SerializeField] private Rigidbody2D rb;
  [SerializeField] private float timeToDestroy = 2f;

  private void OnValidate() {
    if (rb == null) rb = GetComponent<Rigidbody2D>();
  }

  private void Start() {
    rb.bodyType = RigidbodyType2D.Kinematic;
  }

  protected override void RaycastCheck() {
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
    RaycastHit2D hitdown = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.down, distance, playerLayer);

    if (hitup.collider != null) {
      StartCoroutine(ChangeBodyTypeAfterDelay(2f));
    }

    if (rb.bodyType == RigidbodyType2D.Dynamic && hitdown.collider != null) {
      Destroy(hitdown.collider.gameObject);
    }
  }

  private IEnumerator ChangeBodyTypeAfterDelay(float delay) {
    yield return new WaitForSeconds(delay);
    rb.bodyType = RigidbodyType2D.Dynamic;
    Destroy(gameObject, timeToDestroy);
  }
}