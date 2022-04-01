using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    public bool sideBySideMovement = true;

    public Transform[] movePoints;

    public Collider2D squishCollider;

    int curPoint = 0;

    public AudioClip deathSound;
    public AudioSource SFX;

    public LevelController controller;

    // Start is called before the first frame update
    void Start()
    {
        agent = base.GetComponent<UnityEngine.AI.NavMeshAgent>();

        agent.SetDestination(movePoints[curPoint].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    Debug.Log($"{base.name}: Reached wander point");
                    
                    // sorry about this looll
                    switch(curPoint)
                    {
                        case 0:
                            curPoint = 1;
                            break;
                        case 1:
                            curPoint = 0;
                            break;
                    }

                    agent.SetDestination(movePoints[curPoint].position);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Dead!");

            controller.Die();
        }
        
    }

    public void Die()
    {
        SFX.PlayOneShot(deathSound);
        base.gameObject.SetActive(false);
    }
}
