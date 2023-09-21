using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTypeLoader : MonoBehaviour, IService
{
    [SerializeField] int order = 0;
    [SerializeField] string serviceName;
    [SerializeField] List<SimpleBlock> blocks = new List<SimpleBlock>();
    Queue<SimpleBlock> tempBlocks;
    public int Order { get => order;}
    public string Name { get => serviceName; }

    public bool Next()
    {
        if (tempBlocks.Count == 0)
            return false;
        BlockRepository.Set(tempBlocks.Dequeue());
        return true;
    }

    public void StartWork()
    {
        tempBlocks = new Queue<SimpleBlock>(blocks);
        BlockRepository.Clear();
    }
}
