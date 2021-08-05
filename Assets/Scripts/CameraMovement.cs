using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    public float smoothness = 0.125f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 desiredPosition =  player.position + offset;
        transform.position = desiredPosition;
    }
}
