using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBrain : MonoBehaviour
{
    public Transform playerTransform;
    NavMeshAgent agent;
    public bool canSee = false;
    private bool hasPoint = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() //Really basic enemy AI system
    {
        if (canSee)
        {
            agent.destination = playerTransform.position;
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
        WorldBounds worldBounds = GameObject.FindObjectOfType<WorldBounds>();
        Vector3 min = worldBounds.min.position;
        Vector3 max = worldBounds.max.position;

        Vector3 rndPos = new Vector3(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y),
            Random.Range(min.z, max.z)
            );
        agent.destination = rndPos;
        Invoke("Wander", 5);
    }
}
