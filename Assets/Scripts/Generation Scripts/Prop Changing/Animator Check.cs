using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCheck : SceneTypeCheck
{
    [SerializeField]
    private Animator Suburb, City, Army;
    public Animator main;
    // Start is called before the first frame update
    void Start()
    {
        Check();
        Set();
    }
    protected override void CreateSuburbs()
    {
        main = Suburb;
    }
    protected override void CreateCity()
    {
        main = City;
    }
    protected override void CreateArmy()
    {
        main = Army;
    }
    public void Set()
    {
        EnemyBrain enemyBrain = GetComponent<EnemyBrain>();
        enemyBrain.animator = main; 
    }
}
