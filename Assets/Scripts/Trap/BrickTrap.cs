using System.Collections;
using UnityEngine;

public class BrickTrap : Trap {
  [SerializeField] private SpriteRenderer spriteRenderer;
  [SerializeField] private Rigidbody2D rb;
  [SerializeField] private float timeToDestroy = 2f;

  private void OnValidate() {
    if (rb == null) rb = GetComponent<Rigidbody2D>();
    if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
  }

  private void Start() {
    spriteRenderer.enabled = false;
    rb.bodyType = RigidbodyType2D.Kinematic;
  }

  protected override void RaycastCheck() {
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
    RaycastHit2D hitdown = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.down, distance, playerLayer);

    if (hitup.collider != null) {
      spriteRenderer.enabled = true;
      StartCoroutine(ChangeBodyTypeAfterDelay(1f));
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