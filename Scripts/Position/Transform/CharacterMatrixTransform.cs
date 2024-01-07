using Repository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMatrixTransform : MatrixTransform
{
    public override Vector2Int LogicPosition 
    { 
        get => base.LogicPosition;
        set
        {
            MovementMatrix.SetBlock(this, false);
            base.LogicPosition = value;
            MovementMatrix.SetBlock(this, true);
        }
    }
    protected override void OnDelete() => MovementMatrix.SetBlock(this, false);
}
