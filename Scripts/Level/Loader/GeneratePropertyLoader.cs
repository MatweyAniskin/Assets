using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loader
{
    [CreateAssetMenu(menuName = "Loader/Propertys")]
    public class GeneratePropertyLoader : Loader
    {
        [SerializeField] float blockScale = 1;
        [SerializeField] Vector2Int textureCountPerSide = Vector2Int.one;
        [SerializeField] int tileScale = 64;
        [SerializeField] int mapWidth = 10;
        [SerializeField] int mapHeight = 10;
        [SerializeField] int walkebleLayer = 3;
        [SerializeField] int characterHeight = 4;
        [SerializeField] string tagForInstantiateTiles;
        public override bool Next() => false;

        public override void StartWork(MonoBehaviour executor)
        {
            GenerateProperty.BlockScale = blockScale;
            GenerateProperty.UvSideCountTextures = textureCountPerSide;
            GenerateProperty.TileSideLength = tileScale;
            GenerateProperty.MapHeight = mapHeight;
            GenerateProperty.MapWidth = mapWidth;
            GenerateProperty.WalkebleLayer = walkebleLayer;
            GenerateProperty.CharactersHeight = characterHeight;
            GenerateProperty.SpawnTilesObject = GameObject.FindWithTag(tagForInstantiateTiles).transform;
        }
    }
}
