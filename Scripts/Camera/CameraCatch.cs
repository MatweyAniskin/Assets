using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCatch : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    private void Start()
    {
        PlayerMatrixTransform.OnSetStartPosition += SetCameraPosition;
    }
    private void OnDestroy()
    {
        PlayerMatrixTransform.OnSetStartPosition -= SetCameraPosition;
    }
    void SetCameraPosition(MatrixTransform matrix)
    {
        virtualCamera.LookAt = matrix.transform;
        virtualCamera.Follow = matrix.transform;
    }
}
