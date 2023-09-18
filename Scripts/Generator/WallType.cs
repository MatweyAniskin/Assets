using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WallType", menuName = "BlockTypes/WallTypes")]
public class WallType : BlockType
{
    [SerializeField] WallArray[] walls;
    public override SimpleBlock GetBlock(int type, int angle) => walls[type].Get(angle);
}
[System.Serializable]
class WallArray
{
    [SerializeField] string typeName;
    [SerializeField] SimpleBlock[] angleBlocks;
    public SimpleBlock Get(int angle) => angleBlocks[angle];
}