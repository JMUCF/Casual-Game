using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{

    public delegate void OnPLayerWin();
    public static event OnPLayerWin earlyWin;
    public delegate void OnPlayerWinLate();
    public static event OnPlayerWinLate lateWin;

    [SerializeField]
    private GameManager gm;

    private float maxDistance;
    private bool hitDetected;
    private bool canInteract;

    private RaycastHit hit;
    private Vector3 offset;
    private GameObject button;
    private Image buttonImage;
    public Color imageColor, changedColor;
    public AudioClip rummageSound;
    private float timer;
    void Start()
    {
        offset = new Vector3(0f, -0.25f, 0f);
        maxDistance = 1.5f;
        button = GameObject.FindWithTag("InteractButton");
        buttonImage = button.GetComponent<Image>();
        buttonImage.color = imageColor;
    }

    void FixedUpdate()
    {
        hitDetected = Physics.Raycast(transform.position + offset, transform.forward, out hit, maxDistance);
        if (hitDetected)
        {
            //Debug.Log("Hit : " + hit.collider.name);
            if(hit.collider.name == "Sphere")
            {
                timer = timer;
                buttonImage.color = changedColor;
                canInteract = true;
            }
        }
        else
        {
            timer = Time.time;
            buttonImage.color = imageColor;
            canInteract = false;
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (hitDetected)
            Gizmos.DrawRay(transform.position + offset, transform.forward * hit.distance);
        else
            Gizmos.DrawRay(transform.position + offset, transform.forward * maxDistance);
    }

    public void OnTap()
    {
        if (canInteract)
        {
            SFXPlayer.current.PlaySound(rummageSound);
            if(timer >= 30)
            {
                lateWin?.Invoke();
                Debug.Log("LATE");
            }
            else
            {
                earlyWin?.Invoke();
                Debug.Log("earlyWin");
            }
        }
            
    }
}
