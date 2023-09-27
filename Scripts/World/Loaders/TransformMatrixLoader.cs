using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMatrixLoader : Loader
{
    public override bool Next() => false;    

    public override void StartWork()
    {
        TransformRepository.SetTransforms(GenerateProperty.MapWidth, GenerateProperty.MapHeight,GenerateProperty.TileSideLength);
    }
}
