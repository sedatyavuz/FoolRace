using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 nextPos = target.position + offset;
        Vector3 smootPos = Vector3.Lerp(transform.position, nextPos, smoothSpeed);
        transform.position = smootPos;
    }
}
