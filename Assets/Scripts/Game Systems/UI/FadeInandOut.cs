using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInandOut : MonoBehaviour
{

    public CanvasGroup fadeBG;  
    private bool isFading = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        EnemyHitBox.onPlayerLose += FadeAway;
        PlayerInteract.onPLayerWin += FadeAway;
    }
    private void Start()
    {
        fadeBG.alpha = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFading)
        {
            FadeOut();
        }
        else if(!isFading && fadeBG.alpha > 0)
        {
            Fadein();
        }
    }
    void Fadein()
    {
        fadeBG.alpha -= 1f * Time.deltaTime;
    }
    void FadeOut()
    {
        fadeBG.alpha += 1f * Time.deltaTime;
    }
    private void FadeAway()
    {
        isFading = true;
    }
}
