using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    public static Rigidbody2D main;
    void Awake()
    {
        main = rigidbody;   
    } 
    public static float Distance(Vector2 position) => Vector2.Distance(Position, position);
    public static Vector2 Position => main.position;
    public static T GetComponent<T>() => main.GetComponent<T>();
}
