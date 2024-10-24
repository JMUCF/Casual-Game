using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundChange : SceneTypeCheck
{
    [SerializeField]
    private GameObject Suburb, City, Army;

    public void Start()
    {
        Check();
    }
    
    protected override void CreateSuburbs()
    {
        base.CreateSuburbs();
        Suburb.SetActive(true);
    }
    protected override void CreateCity()
    {
        base.CreateSuburbs();
        City.SetActive(true);
    }
    protected override void CreateArmy()
    {
        base.CreateArmy();
        Army.SetActive(true);
    }
}
