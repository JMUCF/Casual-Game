using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{

    [SerializeField]
    private GameManager gm;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gm.LoseState();
        }
    }
}
