using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class FieldOfView : MonoBehaviour //this script is what makes the ghosts vision cone
{

    [Header("Script Refrencese")]
        [SerializeField]
        private EnemyBrain enemyBrain;

    

    [Header("View Cone Settings")]
        [SerializeField]
        private float viewRadius;
        [Range(0, 360), SerializeField]
        private float viewAngle;
        [SerializeField]
        private float meshResolution, edgeDstThreshold;
        [SerializeField]
        private int edgeResolveIterations;

    [Header("Wall/Player Layers")]
        [SerializeField]
        private LayerMask targetMask, obstacleMask; //layer that enemy looks for + layer that blocks vision
        public MeshFilter viewMeshFilter;
        Mesh viewMesh;
    [HideInInspector]
        public List<Transform> visibleTargets = new List<Transform>();

    private BoxCollider hitbox;
       

    void Start()
    {
        SetStats();
        enemyBrain = GetComponentInParent<EnemyBrain>();
        hitbox = GetComponent<BoxCollider>();
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;
        StartCoroutine("FindTargetsWithDelay", .2f);
    } 
    void SetStats()
    {
        if(SceneChange.enemyViewRadius != 0) 
        {
            NavMeshAgent navMeshAgent = GetComponentInParent<NavMeshAgent>();
            navMeshAgent.speed = SceneChange.enemySpeed;
            viewRadius = SceneChange.enemyViewRadius;
            viewAngle = SceneChange.enemyViewAngle;
            //flashlight settings
            Light flashlight = GetComponentInParent<Light>();
            flashlight.range = viewRadius;
            flashlight.innerSpotAngle = viewAngle;
            flashlight.spotAngle = viewAngle;
        }
    }

    IEnumerator FindTargetsWithDelay(float delay) //every so often this code runs to check if the player is in vision
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void LateUpdate()
    {
        DrawFieldOfView();
    }

    void FindVisibleTargets() //this checks if the player is in the vision cone if so i sends the patrollingscript after the player
    {
        visibleTargets.Clear();

        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    Debug.Log("I see you!");
                    enemyBrain.canSee = true;
                    hitbox.enabled = true;
                    StartCoroutine("ExitFOVDelay"); //probably not the most memory efficient to have this here, but this calls coroutine that marks player as not seen after 1.5 seconds.
                                                    //If player is still in view it auto marks to true again and calls the coroutine again, but if they're out of FOV they're chilling.
                }
            }
        }
    }

    void DrawFieldOfView() //this draws the field of view
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        ViewCastInfo oldViewCast = new ViewCastInfo();
        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
            ViewCastInfo newViewCast = ViewCast(angle);

            if (i > 0)
            {
                bool edgeDstThresholdExceeded = Mathf.Abs(oldViewCast.dst - newViewCast.dst) > edgeDstThreshold;
                if (oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDstThresholdExceeded))
                {
                    EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
                    if (edge.pointA != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointA);
                    }
                    if (edge.pointB != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointB);
                    }
                }

            }
            viewPoints.Add(newViewCast.point);
            oldViewCast = newViewCast;
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]); //this makes triangles from each point in the vision cone

            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        viewMesh.Clear();
        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }

    EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast)//this code essentally makes the vision cone smoother when the vision gets cut off
    {
        float minAngle = minViewCast.angle;
        float maxAngle = maxViewCast.angle;
        Vector3 minPoint = Vector3.zero;
        Vector3 maxPoint = Vector3.zero;

        for (int i = 0; i < edgeResolveIterations; i++)
        {
            float angle = (minAngle + maxAngle) / 2;
            ViewCastInfo newViewCast = ViewCast(angle);
            bool edgeDstThresholdExceeded = Mathf.Abs(minViewCast.dst - newViewCast.dst) > edgeDstThreshold;
            if (newViewCast.hit == minViewCast.hit && !edgeDstThresholdExceeded)
            {
                minAngle = angle;
                minPoint = newViewCast.point;
            }
            else
            {
                maxAngle = angle;
                maxPoint = newViewCast.point;
            }
        }

        return new EdgeInfo(minPoint, maxPoint);
    }

    ViewCastInfo ViewCast(float globalAngle) //this just makes the angle and radius that the vision cone can see
    {
        Vector3 dir = DirFromAngle(globalAngle, true);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, viewRadius, obstacleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }

    public struct EdgeInfo
    {
        public Vector3 pointA;
        public Vector3 pointB;

        public EdgeInfo(Vector3 _pointA, Vector3 _pointB)
        {
            pointA = _pointA;
            pointB = _pointB;
        }
    }

    private IEnumerator ExitFOVDelay()
    {
        yield return new WaitForSeconds(1.5f);
        hitbox.enabled = false;
        enemyBrain.canSee = false;
    }

}