using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class GroundChange : SceneTypeCheck
{
    [SerializeField]
    private Material SuburbGround, CityGround, ArmyGround;
    [SerializeField]
    private MeshRenderer ground;
    // Start is called before the first frame update
    void Start()
    {
        Check();
    }
    protected override void CreateSuburbs()
    {
        ground.material = SuburbGround;
    }
    protected override void CreateCity()
    {
        ground.material = CityGround;
    }
    protected override void CreateArmy()
    {
        ground.material = ArmyGround;  
    }
}
