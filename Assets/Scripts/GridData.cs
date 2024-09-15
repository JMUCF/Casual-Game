using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridData //Stores the information of placed items and the positions they take up. Makes a check every time a item is spawned to see if it overlaps with any thing
{
    Dictionary<Vector3Int, PlacementData> placedObjects = new();

    public void AddObjectAt(Vector3Int gridPos, Vector2Int objectSize, int ID, int placeedObjectIndex)
    {
        List<Vector3Int> positionsToOccupy = CalcPos(gridPos, objectSize);
        PlacementData data = new PlacementData(positionsToOccupy, ID, placeedObjectIndex);
        foreach (var pos in positionsToOccupy)
        {
            if (placedObjects.ContainsKey(pos))
            {
                throw new Exception($"Dictionary already contains this cell position {pos}");
            }
            placedObjects[pos] = data;
        }
    }

    private List<Vector3Int> CalcPos(Vector3Int gridPos, Vector2Int objectSize)
    {
        List<Vector3Int> returnVal = new();
        for (int x = 0; x < objectSize.x; x++)
        {
            for (int y = 0; y < objectSize.y; y++)
            {
                returnVal.Add(gridPos + new Vector3Int(x, 0, y));
            }
        }
        return returnVal;
    }

    public bool CanPlaceObjectAt(Vector3Int gridPos, Vector2Int objectSize)
    {
        List<Vector3Int> positionToOccupy = CalcPos(gridPos, objectSize);
        foreach (var pos in positionToOccupy)
        {
            if (placedObjects.ContainsKey(pos))
            {
                return false;
            }
        }
        return true;
    }
}

public class PlacementData
{
    public List<Vector3Int> occupiedPos;
    public int ID { get; private set; }
    public int PlacedObjectIndex { get; private set; }
    public PlacementData(List<Vector3Int> occupiedPos, int iD, int placedObjectIndex)
    {
        this.occupiedPos = occupiedPos;
        ID = iD;
        PlacedObjectIndex = placedObjectIndex;
    }
}
