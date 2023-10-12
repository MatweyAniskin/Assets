using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDirection
{
    public enum DirectionType { Up = 0, Right = 1, Down = 2, Left = 3 };
    public static int Direction(DirectionType type) => (int)type;
}
