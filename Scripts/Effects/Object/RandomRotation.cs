using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class RandomRotation : MonoBehaviour
    {
        [SerializeField] Transform mainObject;
        [SerializeField] Vector3 rotateDirection = Vector3.up;
        [SerializeField] float rotateAngle = 90;
        [SerializeField][Tooltip("Inclusive")] int minMultiplyer = -1;
        [SerializeField][Tooltip("Inclusive")] int maxMultiplyer = 1;
        private void Start()
        {
            var angle = rotateDirection * Random.Range(minMultiplyer, maxMultiplyer + 1) * rotateAngle + mainObject.eulerAngles;
            mainObject.rotation = Quaternion.Euler(angle);
        }
    }

}