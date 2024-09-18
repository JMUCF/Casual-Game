using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    private Renderer renderer;
    private Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
        collider = GetComponent<Collider>();
        collider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
