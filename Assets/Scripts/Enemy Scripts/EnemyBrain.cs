using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static PlayerInteract;

public class EnemyBrain : MonoBehaviour
{
    public Animator animator;
    public delegate void OnPlayerSee();
    public static event OnPlayerSee wasSeen;

    [Header("PlayerStuff")]
    public Transform playerTransform;
    public GameObject player;
    private PlayerController playerController;

    [Header("Navigation")]
    NavMeshAgent agent;
    private Vector3 lastPos;
    public bool canSee = false;
    private bool hasPoint = false;

    [Header("Visuals")]
    [SerializeField] private bool hasJumped = false;
    [SerializeField] private CharaterJump charaterJump;
    public AudioClip jumpSound;

    // Start is called before the first frame update

    void Start()
    {
        EnemyHitBox.onPlayerLose += AttackAnim;
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        playerController = player.GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update() //Really basic enemy AI system
    {
        if (canSee && !playerController.inBush)
        {
            lastPos = playerTransform.position;

            WalkToPoint(lastPos);
            if (!hasJumped)
            {
                wasSeen?.Invoke();
                hasJumped = true;
                SFXPlayer.current.PlaySound(jumpSound);
                charaterJump.StartJumping();
            }
        }
        else
        {
            if (!hasPoint && agent.remainingDistance <= agent.stoppingDistance)
            {
                
                hasPoint = true;
                Wander();
            }
        }
        //Debug.Log(agent.remainingDistance);
        if(agent.remainingDistance <= .5)
        {
            animator.SetFloat("Blend", 0);
        }
    }
    public void AttackAnim()
    {
        animator.SetTrigger("Attack");
    }

    void Wander()
    {
        animator.SetFloat("Blend", 1);
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
