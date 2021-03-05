using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
    private Rigidbody rb;

    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotSpeed, Space.Self);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb = collision.gameObject.GetComponent<Rigidbody>();
            InvokeRepeating(nameof(LeftAddForce), 0, 0.02f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke(nameof(LeftAddForce));
        }
    }

    private void LeftAddForce()
    {
        rb.AddForce(Vector3.left * 10 * rotSpeed, ForceMode.Acceleration);
    }
}
