using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateProperty : MonoBehaviour
{
    /// <summary>
    /// Scale of one side block
    /// </summary>
    public static float BlockScale { get; set; }    
    /// <summary>
    /// Texture count per side of texture atlas
    /// </summary>
    public static float UvSideCountTextures
    {
        get
        {
            return uvSideCountTextures;
        }
        set
        {
            uvSideCountTextures = value;
            UvScale = 1f / uvSideCountTextures;
        }
    }
    /// <summary>
    /// Scale side of one texture in atlas
    /// </summary>
    public static float UvScale { get; private set; }

    protected static float uvSideCountTextures = 1; 
    /// <summary>
    /// Calculated unit tile scale in unity
    /// </summary>
    public static float TileSideScale => BlockScale * TileSideLength;
    /// <summary>
    /// Blocks in one side in Tile
    /// </summary>
    public static int TileSideLength { get; set; } = 64;
    /// <summary>
    /// Map Generated width
    /// </summary>
    public static int MapWidth { get; set; }
    /// <summary>
    /// Map Generated height
    /// </summary>
    public static int MapHeight { get; set; }
}
