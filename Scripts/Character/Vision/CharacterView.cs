using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] NpcBehaviour behaviour;
    [SerializeField] MatrixTransform matrixTransform;
    [SerializeField] int radius = 10;

    int sqareRadius;
    Vector2Int maxMatrixPosition;
    private void Start()
    {
        behaviour.OnBehaviourAction += IsViewEnemy;
        sqareRadius = Mathf.CeilToInt(1f * radius / GenerateProperty.TileSideLength);
        maxMatrixPosition = new Vector2Int(GenerateProperty.MapWidth - 1, GenerateProperty.MapHeight - 1);
    }
    private void OnDestroy()
    {
        behaviour.OnBehaviourAction -= IsViewEnemy;
    }
    void IsViewEnemy()
    {
        if (behaviour.IsTargeting)
            return;
        List<MatrixTransform> transforms = new List<MatrixTransform>();
        Vector2Int temp;
        for (int x = -sqareRadius; x < sqareRadius; x++)
            for (int y = -sqareRadius; y < sqareRadius; y++)
            {
                temp = matrixTransform.SquarePosition + new Vector2Int(x, y);
                temp.Clamp(Vector2Int.zero, maxMatrixPosition);
                transforms.AddRange(TransformRepository.GetTransformsInSquare(temp));
            }

        transforms.ForEach(i =>
        {
            if (i is PlayerMatrixTransform && Vector2Int.Distance(i.Position, matrixTransform.Position) <= radius) //is unit test
            {
                behaviour.SetTarget(i);                
                return;
            }
        }
        );
    }
}
