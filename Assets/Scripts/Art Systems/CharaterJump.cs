using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterJump : MonoBehaviour
{

    float startPos;
    private void Start()
    {
        startPos = transform.position.y;
    }
    
    public void StartJumping()//Tweens to 2 units above its y pos
    {
        transform.LeanMoveLocalY(startPos + 2, .2f).setEaseLinear().setOnComplete(StopJumpng);
    }
    public void StopJumpng()//Returns to normal Y pos
    {
        transform.LeanMoveLocalY(startPos, .5f).setEaseLinear();
    }
}
