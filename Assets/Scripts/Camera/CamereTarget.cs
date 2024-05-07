using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereTarget : MonoBehaviour {
  public Transform target;
  public float smoothSpeed = 0.125f;
  public bool isFollowing;

  public void Start() {
    isFollowing = true;
  }

  private void Update() {
    if (isFollowing) {
      FollowPlayer();
    }
  }

  private void FollowPlayer() {
    Vector3 desiredPosition = new Vector3(target.position.x, 3, transform.position.z);
    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    transform.position = smoothedPosition;
  }
}