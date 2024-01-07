using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCamera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera virtualCamera;
        [SerializeField] float defaultFov = 60;
        [SerializeField] float fovSpeedMultiplyer = 2f;

        float curFov;
        MatrixTransform playerTransform;
        private void Start()
        {
            curFov = defaultFov;
            PlayerMatrixTransform.OnSetStartPosition += SetCameraPosition;
        }
        private void OnDestroy()
        {
            PlayerMatrixTransform.OnSetStartPosition -= SetCameraPosition;
        }
        void SetCameraPosition(MatrixTransform matrix)
        {
            playerTransform = matrix;
            virtualCamera.LookAt = matrix.transform;
            virtualCamera.Follow = matrix.transform;
        }
        /// <summary>
        /// Camera field of view
        /// </summary>
        /// <param name="percent">Percent from default FOV (0 - 2)</param>
        public void SetFov(float percent)
        {
            StopCoroutine(ToFov());
            curFov = defaultFov * Mathf.Clamp(percent,0.01f,2f);
            StartCoroutine(ToFov());
        }
        IEnumerator ToFov()
        {
            float baseFov = virtualCamera.m_Lens.FieldOfView;
            for (float t = 0f; t <= 1; t += Time.deltaTime* fovSpeedMultiplyer)
            {
                virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(baseFov, curFov, t);
                yield return null;
            }
        }
    }
}