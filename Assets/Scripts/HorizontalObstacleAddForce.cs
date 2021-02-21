using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacleAddForce : MonoBehaviour
{
    [SerializeField] private Vector3 AddForceDir;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(AddForceDir,ForceMode.Impulse);
        }
    }
}
