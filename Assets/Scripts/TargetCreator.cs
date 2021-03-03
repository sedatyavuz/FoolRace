using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetCreator : MonoBehaviour
{
    FollowTarget followTarget;

    [SerializeField] private Transform[] Targets;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(other.GetComponent<NavMeshAgent>())
            {
                int RandTransform = Random.Range(0, Targets.Length);
                followTarget = other.GetComponent<FollowTarget>();
                followTarget.setTarget(Targets[RandTransform].transform);
            }
        }
    }
}
