using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTypeLoader : Loader
{   
    [SerializeField] List<SimpleBlock> blocks = new List<SimpleBlock>();
    Queue<SimpleBlock> tempBlocks;   

    public override bool Next()
    {
        if (tempBlocks.Count == 0)
            return false;
        BlockRepository.Set(tempBlocks.Dequeue());
        return true;
    }

    public override void StartWork()
    {
        tempBlocks = new Queue<SimpleBlock>(blocks);
        BlockRepository.Clear();
    }
}
