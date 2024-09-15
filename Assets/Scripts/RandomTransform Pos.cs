using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTransformPos : MonoBehaviour //whole script just makes random positions based of what is needed
{
    //Gets size of plane
    public float planeWidth = 10;
    public float planeHeight = 10;


    private Vector3 lastPos;


    [SerializeField]
    private LayerMask placementLayerMask;
    public Vector3 GetMapPositions()
    {
        var spawnPos = new Vector3(Random.Range(-planeWidth, planeWidth), 2, Random.Range(-planeHeight, planeHeight));
        RaycastHit hit;
        if (Physics.Raycast(spawnPos, Vector3.down, out hit, 100, placementLayerMask))
        {
            lastPos = hit.point;
            return lastPos;
        }
        return lastPos;


    }
    public Vector3 SpawnTrash()
    {
        var spawnPos = new Vector3(Random.Range(-planeWidth, planeWidth), 2, 8);
        RaycastHit hit;
        if (Physics.Raycast(spawnPos, Vector3.down, out hit, 100, placementLayerMask))
        {
            lastPos = hit.point;
            return lastPos;
        }
        return lastPos;


    }
    public Vector3 SpawnPlayer()
    {
        var spawnPos = new Vector3(Random.Range(-planeWidth, planeWidth), 2, -8);
        RaycastHit hit;
        if (Physics.Raycast(spawnPos, Vector3.down, out hit, 100, placementLayerMask))
        {
            lastPos = hit.point;
            return lastPos;
        }
        return lastPos;


    }
    public Vector3 SpawnEnemy()
    {
        var spawnPos = new Vector3(Random.Range(-planeWidth, planeWidth), 2, 8);
        RaycastHit hit;
        if (Physics.Raycast(spawnPos, Vector3.down, out hit, 100, placementLayerMask))
        {
            lastPos = hit.point;
            return lastPos;
        }
        return lastPos;


    }
}
