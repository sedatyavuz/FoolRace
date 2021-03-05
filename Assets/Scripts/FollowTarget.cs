using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    NavMeshAgent agent;

    private Transform Target;

    [SerializeField] private Transform[] Targets;

    [SerializeField] private UIManager uIManager;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Target = transform;
        uIManager.StartValueChange += StartPos;
    }

    void Update()
    {
        agent.SetDestination(Target.position);
    }

    public void setTarget(Transform newPos)
    {
        Target = newPos;
    }

    public void StartPos(bool value)
    {
        if (value)
        {
            int RandTransform = Random.Range(0, Targets.Length);
            Target = Targets[RandTransform];
        }
    }
}
