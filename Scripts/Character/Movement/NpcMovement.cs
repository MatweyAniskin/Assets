using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : CharacterMovement
{
    public override void Action(Vector2Int dir, Stats stats, object[] args = null)
    {
        dir = MatrixTransform.CalculateDirection(dir, matrixTransform.Position);
        base.Action(dir, stats);
    }
}
