using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTransformPos : MonoBehaviour
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
}
