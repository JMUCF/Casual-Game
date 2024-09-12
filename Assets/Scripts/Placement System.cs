using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private RandomTransformPos transformPos;
    [SerializeField]
    private GridLayout grid;

    [SerializeField]
    private ObjectsDataBaseSO database;
    private int selcectedObjectIndex = -1;

    private GridData floorData, furnitureData;

    public int spawnAmount;

    private List<GameObject> placedObjects = new();

    [SerializeField] private GroundNavMesh NavMesh;

    public void Start()
    {
        placedObjects.Clear();
        floorData = new();
        furnitureData = new();
        Transform parent = new GameObject("Walls").transform;
        parent.tag = "Obj";
        for (int i = 0; i < spawnAmount; i++)
        {
            int rng = Random.Range(0, database.objectsData.Count);
            Debug.Log(rng);
            Vector3 spawnPos = transformPos.GetMapPositions();
            Vector3Int gridPos = grid.WorldToCell(spawnPos);
            bool placementValidity = CheckPlacementValilidy(gridPos, rng);
            if (placementValidity == false)
            {
                rng = Random.Range(0, database.objectsData.Count);
                Debug.Log(rng);
                spawnPos = transformPos.GetMapPositions();
                gridPos = grid.WorldToCell(spawnPos);
                placementValidity = CheckPlacementValilidy(gridPos, rng);
                if (placementValidity == false)
                {
                    i--;
                }
                else
                {
                    PlaceStructure(gridPos, rng, parent);
                }
            }
            else
            {
                PlaceStructure(gridPos, rng, parent);
            }
            NavMesh.Build();
        }

    }

    private bool CheckPlacementValilidy(Vector3Int gridPos, int rng)
    {
        GridData selectedData = database.objectsData[rng].ID == 0 ? furnitureData : furnitureData;

        return selectedData.CanPlaceObjectAt(gridPos, database.objectsData[rng].Size);
    }

    private void PlaceStructure(Vector3Int spawnpos, int rng, Transform parent)
    {

        GameObject newObject = Instantiate(database.objectsData[rng].Prefab);
        newObject.transform.position = spawnpos;
        newObject.transform.SetParent(parent);
        placedObjects.Add(newObject);
        GridData selectedData = database.objectsData[rng].ID == 0 ? floorData : furnitureData;
        selectedData.AddObjectAt(spawnpos, database.objectsData[rng].Size, database.objectsData[rng].ID, placedObjects.Count - 1);
    }


}
[CustomEditor(typeof(PlacementSystem)), CanEditMultipleObjects]
public class PlacementSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PlacementSystem grid = (PlacementSystem)target;
        if (GUILayout.Button("Spawn Items"))
        {
            var allObjects = GameObject.FindGameObjectsWithTag("Obj");
            var objs = allObjects.Select(enemy => enemy.gameObject).ToArray();
            foreach (var obj in objs) { DestroyImmediate(obj); }
            grid.Start();
        }
        using (var changeScope = new EditorGUI.ChangeCheckScope())
        {
            float newSpawnChance = EditorGUILayout.Slider("Spawn Chance", grid.spawnAmount, 0, 100);
            if (changeScope.changed)
            {
                Undo.RecordObject(grid, "Changed Spawn Chance"); // To support Undo
                grid.spawnAmount = (int)newSpawnChance;
                EditorUtility.SetDirty(grid); // Mark the object as dirty to save changes
            }
        }
    }
}
