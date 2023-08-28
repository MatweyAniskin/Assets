using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WallType", menuName = "BlockTypes/WallTypes")]
public class WallType : BlockType
{
    [SerializeField] WallArray[] walls;
    public override Block GetBlock(int type, int angle) => walls[type].Get(angle);
}
[System.Serializable]
class WallArray
{
    [SerializeField] string typeName;
    [SerializeField] Block[] angleBlocks;
    public Block Get(int angle) => angleBlocks[angle];
}