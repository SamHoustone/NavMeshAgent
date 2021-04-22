using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController2 : MonoBehaviour
{
    public NavMeshAgent agent;
    private Camera cameraa;
    public ThirdPersonCharacter ThirdPersonCharacter;

    private void Start()
    {
        agent.updateRotation = false;
    }
    void Update()
    {
        if(agent.remainingDistance > agent.stoppingDistance)
        {
            ThirdPersonCharacter.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            GetRandomLocation();
        }

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform transform = other.GetComponent<Transform>();
            agent.SetDestination(transform.position);
        }
        else
        {
            GetRandomLocation();
        }    
    }
    Vector3 GetRandomLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        // Pick the first indice of a random triangle in the nav mesh
        int t = Random.Range(0, navMeshData.indices.Length - 3);

        // Select a random point on it
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
        Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);

        agent.SetDestination(point);
        return point;
    }
}
