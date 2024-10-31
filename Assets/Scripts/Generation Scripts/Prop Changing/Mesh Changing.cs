using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshChanging : SceneTypeCheck
{


    [SerializeField]
    private GameObject Suburb, City, Army;
    private GameObject currentBush;
    [SerializeField] ParticleSystem fx;
    // Start is called before the first frame update
    void Start()
    {
        Check();
    }
    protected override void CreateSuburbs()
    {
        Suburb.SetActive(true);
        currentBush = Suburb;
    }
    protected override void CreateCity()
    {
        City.SetActive(true);
        currentBush = City;
    }
    protected override void CreateArmy()
    {
        Army.SetActive(true);
        currentBush = Army;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("something has entered a bush");
        if (other.CompareTag("Player"))
        {
            fx = currentBush.GetComponentInChildren<ParticleSystem>();
            fx.Play();
        }
    }
}
