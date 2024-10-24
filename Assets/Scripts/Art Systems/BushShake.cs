using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushShake : MonoBehaviour
{
    [SerializeField] Pulse pulse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pulse.pusling = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pulse.pusling = false;
        }
    }
}
