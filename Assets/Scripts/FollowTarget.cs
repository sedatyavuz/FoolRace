using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    NavMeshAgent agent;

    private Transform Target;

    [SerializeField] private Transform[] Targets;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        int RandTransform = Random.Range(0, Targets.Length);
        Target = Targets[RandTransform];
    }

    void Update()
    {
        agent.SetDestination(Target.position);
    }

    public void setTarget(Transform newPos)
    {
        Target = newPos;
    }
}
