using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] protected float speed = 1;
    [SerializeField] protected float accelaration = 10;
    [SerializeField] protected float jumpForce = 3;
    [SerializeField] Vector2 groundCheckOffset = Vector2.zero;
    [SerializeField] float groundCheckDistance = 1f;
    [SerializeField] string groundLayer = "Ground";


    protected bool isAnimated;
    Vector3Int globalPosition;
    bool isGrounded;    

    public delegate void ChangeDirMoving(Vector2 dir);
    public event ChangeDirMoving OnMove;
    public delegate void ChangeMoving();
    public event ChangeMoving OnStop;
    public event ChangeMoving OnJump;
    public event ChangeMoving OnFallStart;
    public event ChangeMoving OnFallEnd;
    public Vector2 MoveMagnitude
    {
        get
        {            
            return rigidBody.velocity;
        }
    }
    public bool IsGrounded => isGrounded;
    protected void StartMove(Vector2 dir) => OnMove?.Invoke(dir);
    protected void StartMove(float x, float y) => StartMove(new Vector2(x,y));
    protected void StartStop() => OnStop?.Invoke();
    public void Move(Vector2 direction) => Move(direction.x, direction.y);
    public void Move(float x, float y)
    {
        // rigidBody.Move(new Vector3(x * speed, -9.8f, y * speed) * Time.deltaTime);
        // rigidBody.AddForce(new Vector2(x * speed, -9.8f) * Time.deltaTime, ForceMode2D.Force);        
        // rigidBody.MovePosition(rigidBody.position + new Vector2(x * speed, 0) * Time.deltaTime);
        float xDir = rigidBody.velocity.x;
        /*if (Mathf.Sign(xDir) * xDir < speed)
            rigidBody.velocity += new Vector2(x * accelaration * Time.deltaTime, 0);
        else*/
            rigidBody.velocity = new Vector2(x * speed, rigidBody.velocity.y);
    }
    public void Jump(float force)
    {
        OnJump?.Invoke();
        rigidBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);        
    }
    public void Jump()
    {
        if(isGrounded)
            Jump(jumpForce);
    }
    public void SetPosition(Vector3Int pos)
    {     
        globalPosition = pos;
        transform.position = new Vector3(pos.x, pos.z * 8, pos.y);   
    }

    private void FixedUpdate()
    {
        bool check = CheckGround();
        if (check != isGrounded)
        {
            if (isGrounded)
            {
                OnFallStart?.Invoke();
            }else
            {
                OnFallEnd?.Invoke();
            }
            isGrounded = check;
        }
    }
    public bool CheckGround() => Physics2D.Raycast(rigidBody.position + groundCheckOffset, Vector2.down, groundCheckDistance,LayerMask.GetMask(groundLayer)).collider != null;
}
/*
 *  public void MoveToDirection(Vector2Int direction)
    {
        if (isAnimated || Matrix.IsCollision(direction, globalPosition))
            return;
        StartCoroutine(Animation(direction));
    }
    public void HardMoveToDirection(Vector2 direction)
    {        
        if (Matrix.IsCollision(direction, globalPosition))
        {     
            isAnimated = false;
            return;
        }        
        transform.position += new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;
        int x = Convert.ToInt32(transform.position.x);        
        int y = Convert.ToInt32(transform.position.z);
        Vector3Int curPos = new Vector3Int(x, y, globalPosition.z);
        
        if (curPos != globalPosition)
        {         
            globalPosition = curPos;
        }
            
    }
    
    IEnumerator Animation(Vector2 dir)
    {
        float index = 0;
        isAnimated = true;
        Vector3 cur = transform.position;
        Vector3 req = new Vector3(dir.x + cur.x,cur.y,dir.y + cur.z);
        while (index < 1)
        {            
            index += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(cur, req, index);
            yield return null;            
        }
        globalPosition += new Vector3Int(Convert.ToInt32(dir.x), Convert.ToInt32(dir.y), 0);
        isAnimated = false;
    }   
*/