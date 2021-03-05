using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutMovingStick : MonoBehaviour
{
    [SerializeField] private Vector3 StartPos;
    [SerializeField] private Vector3 EndPos;
    [SerializeField] private float WaitTime;
    [SerializeField] private float SmoothPosValue;

    private Rigidbody rb;


    void Start()
    {
        InvokeRepeating(nameof(run), WaitTime, 0.02f);
    }

    void run()
    {
        transform.localPosition = new Vector3(transform.localPosition.x - SmoothPosValue, transform.localPosition.y, transform.localPosition.z);
        if (transform.localPosition.x <= EndPos.x)
        {
            CancelInvoke(nameof(run));
            InvokeRepeating(nameof(back), WaitTime, 0.02f);
        }
    }

    void back()
    {
        transform.localPosition = new Vector3(transform.localPosition.x + SmoothPosValue, transform.localPosition.y, transform.localPosition.z);
        if (transform.localPosition.x >= StartPos.x)
        {
            CancelInvoke(nameof(back));
            InvokeRepeating(nameof(run), WaitTime, 0.02f);
        }
    }
}
