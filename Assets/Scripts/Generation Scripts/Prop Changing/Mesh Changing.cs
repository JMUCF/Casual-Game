using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshChanging : SceneTypeCheck
{


    [SerializeField]
    private GameObject Suburb, City, Army;
    // Start is called before the first frame update
    void Start()
    {
        Check();
    }
    protected override void CreateSuburbs()
    {
        Suburb.SetActive(true);
    }
    protected override void CreateCity()
    {
        City.SetActive(true);
    }
    protected override void CreateArmy()
    {
        Army.SetActive(true);
    }
}
