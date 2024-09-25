using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    private Renderer renderer;
    private Collider collider;
    public GameObject player;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("something has entered a bush");
        if(other.CompareTag("Player"))
        {
            player = other.gameObject;
            playerController = player.GetComponent<PlayerController>();
            playerController.inBush = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("something has exited a bush");
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            playerController = player.GetComponent<PlayerController>();
            playerController.inBush = false;
        }
    }
}
