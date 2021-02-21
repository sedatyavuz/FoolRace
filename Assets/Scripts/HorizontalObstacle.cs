using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{
    [SerializeField] private Vector3 StartPos;
    [SerializeField] private Vector3 EndPos;
    [SerializeField] private float Speed;

    private Vector3 nextPos;

    private void Start()
    {
        nextPos = EndPos;
    }

    private void Update()
    {
        if (transform.localPosition == StartPos)
        {
            nextPos = EndPos;
        }
        if (transform.localPosition == EndPos)
        {
            nextPos = StartPos;
        }
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, nextPos, Speed * Time.deltaTime);
    }
}
