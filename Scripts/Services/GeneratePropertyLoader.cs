using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePropertyLoader : Loader
{    
    [SerializeField] float blockScale = 1;
    [SerializeField] float textureCountPerSide = 1;
    [SerializeField] int tileScale = 64;
    [SerializeField] int mapWidth = 10;
    [SerializeField] int mapHeight = 10;     
    public override bool Next() => false;

    public override void StartWork()
    {
        GenerateProperty.BlockScale = blockScale;
        GenerateProperty.UvSideCountTextures = textureCountPerSide;
        GenerateProperty.TileSideLength = tileScale;
        GenerateProperty.MapHeight = mapHeight;
        GenerateProperty.MapWidth = mapWidth;
    }
}
