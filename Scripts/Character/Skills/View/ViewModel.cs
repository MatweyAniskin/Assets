using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModel 
{
    public Vector2Int Start { get; private set; }
    public Vector2Int End { get; private set; }
    public ViewModel(Vector2Int rectangleStart, Vector2Int rectangleEnd)
    {
        Start = rectangleStart;
        End = rectangleEnd;
    }
}
