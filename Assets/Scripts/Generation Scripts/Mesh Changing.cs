using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshChanging : MonoBehaviour
{

    [SerializeField]
    private Mesh Suburb, City, Army;
    [SerializeField]
    private Material SuburbMat, CityMat, ArmyMat;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SceneChange.propType);
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if(SceneChange.propType == "Suburbs")
        {
            meshFilter.mesh = Suburb;
            meshRenderer.material = SuburbMat;
        }
        else if (SceneChange.propType == "City")
        {
            meshFilter.mesh = City;
            meshRenderer.material = CityMat;
        }
        else if (SceneChange.propType == "Army")
        {
            meshFilter.mesh = Army;
            meshRenderer.material = ArmyMat;
        }
    }
}
