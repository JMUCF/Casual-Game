using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBrain : MonoBehaviour
{
    public Transform playerTransform;
    NavMeshAgent agent;
    private Animator animator;
    public bool canSee = false;
    private bool hasPoint = false;
    private bool hasJumped = false;
    private Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update() //Really basic enemy AI system
    {
        if (canSee)
        {
            lastPos = playerTransform.position;
            Debug.Log("I canSee You");
            WalkToPoint(lastPos);
            if (!hasJumped)
            {
                hasJumped = true;
                animator.SetTrigger("Jump");
            }
        }
        else
        {
            
           if(!hasPoint)
           {
                hasPoint = true;
                Wander();
           }
        }

    }

    void Wander()
    {
        hasJumped = false;
        WorldBounds worldBounds = GameObject.FindObjectOfType<WorldBounds>();
        Vector3 min = worldBounds.min.position;
        Vector3 max = worldBounds.max.position;

        Vector3 rndPos = new Vector3(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y),
            Random.Range(min.z, max.z)
            );
        WalkToPoint(rndPos);
        Invoke("Wander", 5);
    }
    void WalkToPoint(Vector3 pos)
    {
        agent.destination = pos;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(lastPos, .5f);
    }
}
