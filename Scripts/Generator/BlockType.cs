using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockType : ScriptableObject
{
    public abstract Block GetBlock(int type, int angle);
    public static bool operator ==(BlockType a, string b) => a.name == b;
    public static bool operator !=(BlockType a, string b) => a.name != b;
}
