using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshChanging : MonoBehaviour
{

    [SerializeField]
    private Mesh Suburb, City, Army;
    [SerializeField]
    private Material[] SuburbMat, CityMat, ArmyMat;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning(SceneChange.propType);
        if(SceneChange.propType != null)
        {
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (SceneChange.propType == "Suburbs")
            {
                meshFilter.mesh = Suburb;
                meshRenderer.materials = SuburbMat;
            }
            else if (SceneChange.propType == "City")
            {
                meshFilter.mesh = City;
                meshRenderer.materials = CityMat;
            }
            else if (SceneChange.propType == "Army")
            {
                meshFilter.mesh = Army;
                meshRenderer.materials = ArmyMat;
            }
        } 
    }
}
