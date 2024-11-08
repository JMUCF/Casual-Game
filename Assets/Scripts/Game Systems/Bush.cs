using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    private new Renderer renderer;
    public GameObject player;
    public GameObject enemy;
    private GameObject enemyColliderObj;
    public PlayerController playerController;

    private AudioClip bushClip;
    public AudioClip bush, trash, metal;
    // Start is called before the first frame update

    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
        enemy = GameObject.Find("Enemy");
        enemyColliderObj = enemy.transform.GetChild(0).gameObject;
        switch (SceneChange.propType.ToString())
        {
            case "Suburbs":
                bushClip = bush;
                break;
            case "City":
                bushClip = trash;
                break;
            case "Army":
                bushClip = metal;
                break;
            default:
                bushClip = bush;
                break;
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("something has entered a bush");
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            playerController = player.GetComponent<PlayerController>();
            playerController.inBush = true;
            SFXPlayer.current.PlaySound(bushClip);
            //enemyColliderObj.SetActive(false);
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
            //enemyColliderObj.SetActive(true);
        }
    }
}