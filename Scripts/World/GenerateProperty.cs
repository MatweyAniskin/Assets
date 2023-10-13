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
    public static Vector2Int UvSideCountTextures
    {
        get
        {
            return uvSideCountTextures;
        }
        set
        {
            uvSideCountTextures = value;
            UvScale = new Vector2(1f / uvSideCountTextures.x, 1f / uvSideCountTextures.y);
        }
    }
    /// <summary>
    /// Scale side of one texture in atlas
    /// </summary>
    public static Vector2 UvScale { get; private set; }

    protected static Vector2Int uvSideCountTextures = Vector2Int.one; 
    /// <summary>
    /// Calculated unit tile scale in unity
    /// </summary>
    public static float TileSideScale => BlockScale * TileSideLength;
    /// <summary>
    /// Blocks in one side in Tile
    /// </summary>
    public static int TileSideLength { get; set; } = 64;
    /// <summary>
    /// Map Generated tiles length in width (x)
    /// </summary>
    public static int MapWidth { get; set; }
    /// <summary>
    /// Map Generated tiles length in height (y)
    /// </summary>
    public static int MapHeight { get; set; }

    /// <summary>
    /// Map lenght blocks in height
    /// </summary>
    public static int MapHeightBlockLength => TileSideLength * MapHeight;
    /// <summary>
    /// Map lenght blocks in width
    /// </summary>
    public static int MapWidthBlockLength => TileSideLength * MapWidth;
    /// <summary>
    /// Layer in tile blocks (y) for walk
    /// </summary>
    public static int WalkebleLayer { get; set; }
}
