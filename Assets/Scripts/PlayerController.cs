using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    private Camera cameraa;
    private CapsuleCollider capsuleCollider;
    public ThirdPersonCharacter ThirdPersonCharacter;

    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        agent.updateRotation = false; 
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cameraa = FindObjectOfType<Camera>();
            Ray ray = cameraa.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            ThirdPersonCharacter.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            ThirdPersonCharacter.Move(Vector3.zero, false, false);
        }
    }
}
