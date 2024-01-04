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
    public Animator animator;
    
    NavMeshAgent agent;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        
        agent.speed = speed;

        var currentSpeed = agent.velocity.magnitude;
		var distance = Vector3.Distance(transform.position, target.position);

		if (distance < 1.5f)
		{
			// JUMPSCARE
			speed = 0;
			animator.Play("Scream");
		} else if (currentSpeed == 0)
		{
			animator.Play("Idle");
		}
		else if(currentSpeed < 4)
		{
			animator.Play("Walk");
		}
		else
		{
			animator.Play("Run");
		}
        
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

        if (distance < 1f)
        {
            animator.Play("Scream");
        }

    }
}
