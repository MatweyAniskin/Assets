using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModel 
{
    Vector2Int Start { get; set; }
    Vector2Int End { get;  set; }
    public ViewModel(Vector2Int rectangleStart, Vector2Int rectangleEnd)
    {
        Start = rectangleStart;
        End = rectangleEnd;
    }
    public ViewModel(Vector2Int center, int radius)
    {
        Start = new Vector2Int(center.x - radius, center.y-radius);
        End = new Vector2Int(center.x + radius, center.y + radius);
    }
    int ClampY(int value) => Clamp(value, GenerateProperty.MapHeightBlockLength);
    int ClampX(int value) => Clamp(value, GenerateProperty.MapWidthBlockLength);
    int Clamp(int value, int max) => Mathf.Clamp(value,0, max);
    public IEnumerable<Vector2Int> GetViewBlocks()
    {
        List<Vector2Int> blocks = new List<Vector2Int>();
        for (int x = ClampX(Start.x); x < ClampX(End.x); x++)
            for (int y = ClampY(Start.y); y < ClampY(End.y); y++)            
                blocks.Add(new Vector2Int(x, y));
        return blocks;
    }
}
