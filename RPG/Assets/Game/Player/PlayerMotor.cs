using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Interactable _target;
    private Interactable _lastInteract = null;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_target != null)
        {
            var targetPosition = _target.interactionTransform.position;
            
            _agent.SetDestination(targetPosition);

            float distance = Vector3.Distance(transform.position, targetPosition);
            if (distance <= _target.radius)
            {
                FaceTarget();
                
                if (_lastInteract == _target) return;
                
                _target.Interact(gameObject);
                _lastInteract = _target;
            }
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        _agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        _lastInteract = null;
        _agent.stoppingDistance = newTarget.radius * .8f;
        _target = newTarget;
    }

    public void StopFollowingTarget()
    {
        _agent.stoppingDistance = 0f;
        _target = null;
    }

    private void FaceTarget()
    {
        Vector3 direction = (_target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
