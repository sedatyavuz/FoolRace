using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStick : MonoBehaviour
{
    [SerializeField] private float rotSpeed;

    void Update()
    {
        transform.Rotate(0, Time.deltaTime * rotSpeed, 0, Space.Self);
    }

    public void rotSpeedUp()
    {
        rotSpeed *= 2;
    }

    public void rotSpeedDown()
    {
        rotSpeed /= 2;
    }
}
