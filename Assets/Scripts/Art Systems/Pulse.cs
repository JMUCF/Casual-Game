using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [Tooltip("How long the animation will take to finish")]
    [SerializeField] float expandDuration = 1.0f;
    [SerializeField] Vector3 breathIn;
    [SerializeField] Vector3 breathOut;

    public bool pusling = false;

    private float currentTime = 0;  

    private bool breathingIn = true;

    private void Update()
    {
        PulseUpdate();
    }
    public void PulseUpdate()
    {
        {
            if(pusling)
            {
                Vector3 targetScale = breathingIn ? breathIn : breathOut;
                Vector3 startScale = breathingIn ? breathOut : breathIn;

                currentTime += Time.deltaTime;
                float lerpFactor = currentTime / expandDuration;

                targetObject.transform.localScale = Vector3.Lerp(startScale, targetScale, lerpFactor);

                if(lerpFactor >= 1f)
                {
                    breathingIn = !breathingIn;
                    currentTime = 0;
                }
            }
        }
    }
}
