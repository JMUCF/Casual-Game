using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class GroundNavMesh : MonoBehaviour //Builds nav mesh
{
    [SerializeField]
    private NavMeshSurface navMeshSurface;
    // Start is called before the first frame update
    void Start()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
        Invoke("Build", 1);
    }

    public void Build()
    {

        navMeshSurface.BuildNavMesh();
    }
}
