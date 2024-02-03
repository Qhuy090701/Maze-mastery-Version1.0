using UnityEngine;

public class TrapWallLandR : Trap {
  [SerializeField] private GameObject gameobjectA;
  [SerializeField] private GameObject gameobjectB;
  [SerializeField] private Transform maxPositionA;
  [SerializeField] private Transform maxPositionB;

  private void Update() {
    base.Update();
  }

  protected override void RaycastCheck() {
    RaycastHit2D hitup = Physics2D.BoxCast(transform.position, new Vector2(raycastWidth, raycastHeight), 0f, Vector2.up, distance, playerLayer);
    Debug.DrawRay(transform.position, Vector2.up * distance, Color.red);
    if (hitup.collider != null) {
      if (gameobjectA.transform.position.x < maxPositionA.position.x) {
        gameobjectA.transform.Translate(Vector2.left * Time.deltaTime);
      }
      else {
        gameobjectA.transform.position = maxPositionA.position;
      }

      if (gameobjectB.transform.position.x > maxPositionB.position.x) {
        gameobjectB.transform.Translate(Vector2.right * Time.deltaTime);
      }
      else {
        gameobjectB.transform.position = maxPositionB.position;
      }
    }
  }
}