using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloorSimpleType", menuName = "BlockTypes/FloorSimpleTypes")]
public class FloorSimpleType : BlockType
{
    [SerializeField] SimpleBlock block;
    public override SimpleBlock GetBlock(int type, int angle) => block;    
}
