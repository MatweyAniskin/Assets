using UnityEngine;

public class Occlusion : MonoBehaviour
{
    [SerializeField] int radius = 5;
    [SerializeField] Transform spawnObject;
    MatrixTransform playerTransform;
    private void Start()
    {
        LoadQueue.OnLoadStackEnd += SetOcclusion;
    }
    private void OnDestroy()
    {
        LoadQueue.OnLoadStackEnd -= SetOcclusion;
    }
    void SetOcclusion()
    {
        playerTransform = spawnObject.GetComponentInChildren<PlayerMatrixTransform>();
        playerTransform.OnSquareChange += RecalculateSquares;
        DisableAll();
        RecalculateSquares(playerTransform.SquarePosition);
    }
    void RecalculateSquares(Vector2Int pos) => RecalculateSquares(pos, pos, true);
    void RecalculateSquares(Vector2Int next, Vector2Int last) => RecalculateSquares(next, last, false);
    void RecalculateSquares(Vector2Int next, Vector2Int last, bool ignoreDeactive)
    {
        CalculateField(next, out int minXActive, out int minYActive, out int maxXActive, out int maxYActive);
        CalculateField(last, out int minXDeactive, out int minYDeactive, out int maxXDeactive, out int maxYDeactive);
        bool isActive;
        for (int x = Mathf.Min(minXDeactive, minXActive); x < Mathf.Max(maxXActive, maxXDeactive); x++)
        {
            for (int y = Mathf.Min(minYDeactive, minYActive); y < Mathf.Max(maxYActive, maxYDeactive); y++)
            {
                if (CheckCross(x, y, minXDeactive, minYDeactive, maxXDeactive, maxYDeactive, minXActive, minYActive, maxXActive, maxYActive) && !ignoreDeactive)
                    continue;
                isActive = CheckField(x, y, minXActive, minYActive, maxXActive, maxYActive);
                MatrixViewRepository.SetActive(x, y, isActive);
                foreach (var t in TransformRepository.GetTransformsInSquare(x, y))
                    t.SetActive(isActive);
            }
        }
    }
    bool CheckCross(int x, int y, int minX, int minY, int maxX, int maxY, int minXA, int minYA, int maxXA, int maxYA) => CheckField(x, y, minX, minY, maxX, maxY) && CheckField(x, y, minXA, minYA, maxXA, maxYA);
    bool CheckField(int x, int y, int minX, int minY, int maxX, int maxY) =>  x >= minX && x < maxX && y >= minY && y < maxY;  
    void CalculateField(Vector2Int pos, out int minX, out int minY, out int maxX, out int maxY)
    {
        minX = Mathf.Max(pos.x - radius, 0);
        maxX = Mathf.Min(pos.x + radius+1, MatrixViewRepository.Width);
        minY = Mathf.Max(pos.y - radius, 0);
        maxY = Mathf.Min(pos.y + radius+1, MatrixViewRepository.Height);
    }
    void DisableAll()
    {
        for (int x = 0; x < MatrixViewRepository.Width; x++)
        {
            for (int y = 0; y < MatrixViewRepository.Height; y++)
            {
                MatrixViewRepository.SetActive(x, y, false);
                foreach (var t in TransformRepository.GetTransformsInSquare(x, y))
                    t.SetActive(false);
            }
        }
    }
}
