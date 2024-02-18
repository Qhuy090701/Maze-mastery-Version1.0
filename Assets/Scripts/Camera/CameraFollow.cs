using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    private void Update() {
        transform.position = new Vector3(target.position.x, 4, transform.position.z);
    }
}
