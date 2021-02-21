using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFall : MonoBehaviour
{
    [SerializeField] private Transform[] respawnPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            int randTemp = Random.Range(0, respawnPos.Length);
            other.transform.localPosition = respawnPos[randTemp].position;
        }
    }
}
