using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] float paralaxSpeed;

    Transform mainCamera;
    private void Start()
    {
        mainCamera = Camera.main.transform;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, mainCamera.position, Time.deltaTime * paralaxSpeed);
    }
}
