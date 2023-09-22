using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPropertyLoader : MonoBehaviour, IService
{
    [SerializeField] int order;
    [SerializeField] string serviceName;    
    [SerializeField] float blockScale = 1;
    [SerializeField] float textureCountPerSide = 1;    
    public int Order { get => order; set => order = value; }
    public string Name { get => serviceName; set => serviceName = value; }

    public bool Next() => false;

    public void StartWork()
    {
        SimpleBlock.BlockScale = blockScale;
        SimpleBlock.UvSideCountTextures = textureCountPerSide;
    }
}
