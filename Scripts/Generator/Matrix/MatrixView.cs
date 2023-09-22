using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixView : MonoBehaviour
{
    [SerializeField] int viewRadius = 4;
    Camera camera;
    Tile[,] curTiles;
    Tile[,] nextTiles;

    private void Start()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        
    }
    void ReDrawTiles()
    {
        for(int x = 0; x < viewRadius; x++)
        {
            for (int y = 0; y < viewRadius; y++)

        }
    }
}
