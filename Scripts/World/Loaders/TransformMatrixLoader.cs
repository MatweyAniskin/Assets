using Repository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loader.Generator
{
    [CreateAssetMenu(menuName = "Loader/TransformMatrix")]
    public class TransformMatrixLoader : Loader
    {
        public override bool Next() => false;

        public override void StartWork(MonoBehaviour executor)
        {
            TransformRepository.SetTransforms(GenerateProperty.MapWidth, GenerateProperty.MapHeight, GenerateProperty.TileSideLength);
        }
    }
}
