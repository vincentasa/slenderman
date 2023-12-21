using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float viewDistance;
    public float wanderDistance;
    
    NavMeshAgent agent;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        var distance = Vector3.Distance(transform.position, target.position);
        
        if (distance < viewDistance)
        {
            agent.destination = target.position;
        }
        else
        {
            if (agent.velocity == Vector3.zero)
            {
                var offset = Random.insideUnitSphere * wanderDistance;
                agent.destination = transform.position + offset;
            }
         
        }
    
    
    }
}
