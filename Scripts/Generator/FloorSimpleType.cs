using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloorSimpleType", menuName = "BlockTypes/FloorSimpleTypes")]
public class FloorSimpleType : BlockType
{
    [SerializeField] Block block;
    public override Block GetBlock(int type, int angle) => block;    
}
