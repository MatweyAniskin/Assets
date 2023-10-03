using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartTransformToMatrixTransform : MonoBehaviour
{
    [SerializeField] MatrixTransform matrixTransform;
    void Start()
    {
        matrixTransform.SetStartPosition(transform.position);
    }
}
