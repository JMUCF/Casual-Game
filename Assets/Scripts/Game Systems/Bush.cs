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

    public AudioClip bushClip;
    // Start is called before the first frame update

    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
        enemy = GameObject.Find("NewEnemyPlaceHolder");
        enemyColliderObj = enemy.transform.GetChild(0).gameObject;
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