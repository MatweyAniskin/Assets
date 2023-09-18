using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloorType", menuName = "BlockTypes/FloorTypes")]
public class FloorType : BlockType
{
    [Tooltip("0: Single, 1 Middle, 2 Up, 3 Right, 4 Left, 5 Down, 6 Left")]
    [SerializeField] SimpleBlock[] blocks;
    public override SimpleBlock GetBlock(int type, int angle) => blocks[type];    
}
