using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSimpleController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] float moveSpeed = 3;
    void Update()
    {
        characterController.Move(new Vector3(Input.GetAxis("Horizontal")*Time.deltaTime* moveSpeed, -9.8f, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed));
    }
}
