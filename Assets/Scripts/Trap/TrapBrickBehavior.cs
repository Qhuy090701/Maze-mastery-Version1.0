using System.Collections;
using UnityEngine;

public class TrapBrickBehavior : MonoBehaviour {
  [SerializeField] private SpriteRenderer spriteRenderer;
  [SerializeField] private LayerMask playerLayer;
  [SerializeField] private float distance;
  [SerializeField] private Rigidbody2D rb;
  [SerializeField] private float raycastWidth = 0.5f;
  [SerializeField] private float raycastHeight = 0.1f;
  [SerializeField] private float timeToDestroy = 2f;

  private void OnValidate() {
    if (rb == null) rb = GetComponent<Rigidbody2D>();
    if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
  }

  private void Start() {
    spriteRenderer.enabled = false;
    rb.bodyType = RigidbodyType2D.Kinematic;
  }

  private void Update() {
    RaycastCheck();
  }

  private void RaycastCheck() {
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