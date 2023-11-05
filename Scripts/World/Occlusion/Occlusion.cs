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
        RecalculateSquares(playerTransform.SquarePosition, playerTransform.SquarePosition);
    }
    void RecalculateSquares(Vector2Int next, Vector2Int last)
    {     
        CalculateField(next, out int minXActive, out int minYActive, out int maxXActive, out int maxYActive);
        CalculateField(last, out int minXDeactive, out int minYDeactive, out int maxXDeactive, out int maxYDeactive);    
        for (int x = Mathf.Min(minXDeactive, minXActive); x < Mathf.Max(maxXActive, maxXDeactive); x++)
        {
            for (int y = Mathf.Min(minYDeactive, minYActive); y < Mathf.Max(maxYActive, maxYDeactive); y++)
            {
                MatrixViewRepository.SetActive(x, y, CheckField(x,y,minXActive,minYActive,maxXActive,maxYActive));
            }
        }
    }
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
            }
        }
    }
}
