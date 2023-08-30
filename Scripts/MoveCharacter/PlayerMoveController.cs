using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MoveCharacter
{
    bool isMoving;
    float deltaX = 0;
    private void Start()
    {
      //  SetPosition(Vector3Int.zero);        
    }
    void Update()
    {
        //if (!WindowController.IsOpened) return;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x != 0 || y != 0)
        {
            Move(x, y);
            if (!isMoving || Mathf.Sign(x) != Mathf.Sign(deltaX))
            {
                isMoving = true;
                StartMove(x,y);
                deltaX = x;
            }
            
        }else
        {
            if (isMoving)
            {
                isMoving = false;
                StartStop();
                deltaX = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}
