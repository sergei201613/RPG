using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    private const float LocomotionSmoothTime = .1f;
    
    private NavMeshAgent _agent;
    private Animator _animator;
    private static readonly int Speed = Animator.StringToHash("speed");

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float speed = _agent.velocity.magnitude / _agent.speed;
        _animator.SetFloat(Speed, speed, LocomotionSmoothTime, Time.deltaTime);
    }
}
